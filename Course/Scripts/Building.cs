using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UIElements;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using UnityEngine.UI;
using System.Data.SqlTypes;

public abstract class Building : MonoBehaviour
{
    public string name;
    public GameObject model;
    public ModelList modelList;
    public int Length;
    public int Width;
    public City city;
    public int moneyToBuild = 0;
    public int woodToBuild = 0;
    public int toolToBuild = 0;
    public void CreateObject() 
    {
        model = Instantiate(modelList.dictionary[name]);
        model.transform.parent = gameObject.transform;
        city = modelList.gameObject.GetComponent<City>();
    }
    public void MoveObject(Vector3 position)
    {
        position = new Vector3((float)Math.Round(position.x), 
            model.transform.position.y, 
            (float)Math.Round(position.z));
        model.transform.position = position;
    }
    public abstract string SetInformation();
}


public abstract class Resource: Building
{
    public string ParentType;
    ResourceConsumer ParentBuilding;
    public bool CheckNearbyBuildings()
    {
        int x = (int)model.transform.position.x;
        int y = (int)model.transform.position.z;
        Building t;
        if (x >= Length + 1)
        {
            t = city.matrix[x - Length - 1, y];
            if (DoesFits(t)) return true;
        }
        if (x <= 1000 - Length - 1)
        {
            t = city.matrix[x + Length + 1, y];
            if (DoesFits(t)) return true;
        }
        if (y >= Width + 1)
        {
            t = city.matrix[x, y - Width - 1];
            if (DoesFits(t)) return true;
        }
        if (y <= 1000 - Width - 1)
        {
            t = city.matrix[x, y + Width + 1];
            if (DoesFits(t)) return true;
        }
        ParentBuilding = null;
        return false;

    }
    public bool DoesFits(Building t)
    {
        if (t == null) return false;
        if (t.name == name) t = (t as Resource).ParentBuilding;
        if (t.name == ParentType && (t as ResourceConsumer).canBeAdded())
        {
            ParentBuilding = t as ResourceConsumer;
            return true;
        }
        return false;
    }
    public void SetParent()
    {
        ParentBuilding.countOfResource++;
    }
}


public interface IProductiveBuilding : ICitizenConsist
{
    public List<(string, int)> ConsumeProducts { get; set; }
    public (string, float) Product { get; set; }
    public int Productivity { get; set; }
    public void Produce();
    public void Consume();
}


public interface ICitizenConsist
{
    int countOfCitizens { get; set; }
    public void AddCitizen(int n);
    public void RemoveCitizen(int n);
    public bool CanCitizenBeAdded();
}
public abstract class ResourceConsumer: Building
{
    public int countOfResource;
    public int maxResource;
    public bool canBeAdded()
    {
        return countOfResource < maxResource;
    }
}


public interface Upgradable
{
    int Level { get; set; }
    public void Upgrade();
    public bool CanBeUpgraded();
}


public class WindMill: ResourceConsumer, Upgradable, IProductiveBuilding
{
    public int countOfCitizens { get; set; } = 0;
    public int Productivity { get; set; } = 0;
    public void AddCitizen(int n)
    {
        countOfCitizens+= n;
    }
    public void RemoveCitizen(int n)
    {
        countOfCitizens -= n;
    }
    public bool CanCitizenBeAdded()
    {
        return countOfCitizens < countOfResource;
    }
    public (string, float) Product { get; set; } = ("Bread", 0);
    public List<(string, int)> ConsumeProducts { get; set; } = new List<(string, int)>() { ("money", 0) };
    public int Level { get; set; } = 1;
    public WindMill()
    {
        name = "Wind Mill";
        Length = 4;
        Width = 4;
        maxResource = 4;
        woodToBuild = 10;
        moneyToBuild = 1000;
    }
    public void Upgrade()
    {
        Vector3 positiion = model.transform.position;
        Destroy(model);
        model = Instantiate(modelList.dictionary[name + "2"], new Vector3(positiion.x, 6.5f, positiion.z), new Quaternion());
        model.transform.parent = gameObject.transform;
        Level++;
        maxResource = 8;
        city.tools -= 10; city.wood -= 20;
    }
    public bool CanBeUpgraded()
    {
        return (Level < 2) && (city.tools >= 10) && (city.wood >= 20);
    }
    public override string SetInformation()
    {
        string s = "Name: " + name + "\nProduct: " + Product.Item1 + " " + Product.Item2;
        foreach (var x in ConsumeProducts)
        {
            s += "\nConsume product: " + x.Item2 + " " + x.Item1;
        }
        return s;
    }
    public void Produce()
    {
        Product = (Product.Item1, ((float)Level + 1f) / 2f * Productivity * 8);
        city.bread += Product.Item2 * Time.deltaTime / 5;
    }
    public void Consume()
    {
        Productivity = (int)Math.Min(countOfCitizens * 25, city.money)/25;
        ConsumeProducts[0] = (ConsumeProducts[0].Item1,Productivity * 25);
        city.money -= ConsumeProducts[0].Item2 * Time.deltaTime / 5;
    }
}


public class Wheat: Resource
{
    public WindMill ParentBuilding;
    public Wheat()
    {
        name = "Wheat";
        ParentType = "Wind Mill";
        Length = 5;
        Width = 5;
        moneyToBuild = 200;
    }
    public override string SetInformation()
    {
        return ("Name: " + name);
    }
}


public class Woods: Resource
{
    public SawMill ParentBuilding;
    public Woods()
    {
        name = "Woods";
        ParentType = "Saw Mill";
        Length = 5;
        Width = 5;
        moneyToBuild = 150;
    }
    public override string SetInformation()
    {
        return ("Name: " + name);
    }
}


public class House: Building, Upgradable, ICitizenConsist
{
    public int countOfCitizens { get; set; }
    public int Level { get; set; } = 1;
    public void AddCitizen(int n)
    {
        countOfCitizens += n;
        city.AddCitizens(n);
    }
    public void RemoveCitizen(int n)
    {
        countOfCitizens -= n;
    }
    public bool CanCitizenBeAdded()
    {
        return countOfCitizens < 4;
    }
    public House()
    {
        name = "House";
        Length = 3;
        Width = 3;
        woodToBuild = 5;
        moneyToBuild = 400;
    }
    public override string SetInformation()
    {
        return ("Name: " + name);
    }
    public void Upgrade()
    {
        Vector3 positiion = model.transform.position;
        Destroy(model);
        model = Instantiate(modelList.dictionary[name + "2"], new Vector3(positiion.x, 0f, positiion.z), new Quaternion());
        model.transform.parent = gameObject.transform;
        Level++;
        city.wood -= 10; city.money -= 700;
        city.ConvertCitizens(countOfCitizens);
    }
    public bool CanBeUpgraded()
    {
        return (Level < 2) && (city.wood > 10) && (city.money > 700);
    }
}


public class SawMill: ResourceConsumer, IProductiveBuilding
{
    public int countOfCitizens { get; set; }
    public int Productivity { get; set; } = 0;
    public (string, float) Product { get; set; } = ("Wood", 0);
    public List<(string, int)> ConsumeProducts { get; set; } = new List<(string, int)>() { ("money", 0) };
    public void AddCitizen(int n)
    {
        countOfCitizens += n;
    }
    public void RemoveCitizen(int n)
    {
        countOfCitizens -= n;
    }
    public bool CanCitizenBeAdded()
    {
        return countOfCitizens < countOfResource;
    }
    public SawMill()
    {
        name = "Saw Mill";
        Length = 2;
        Width = 2;
        maxResource = 5;
        woodToBuild = 10;
        moneyToBuild = 800;
    }
    public override string SetInformation()
    {
        string s = "Name: " + name + "\nProduct: " + Product.Item1 + " " + Product.Item2;
        foreach (var x in ConsumeProducts)
        {
            s += "\nConsume product: " + x.Item2 + " " + x.Item1;
        }
        return s;
    }
    public void Produce()
    {
        Product = (Product.Item1, Productivity * 2);
        city.wood += Product.Item2 * Time.deltaTime / 5;
    }
    public void Consume()
    {
        Productivity = (int)Math.Min(countOfCitizens * 10, city.money) / 10;
        ConsumeProducts[0] = (ConsumeProducts[0].Item1, Productivity * 10);
        city.money -= ConsumeProducts[0].Item2 * Time.deltaTime / 5;
    }
}


public class Farm : Building, IProductiveBuilding
{
    public int countOfCitizens { get; set; }
    public int Productivity { get; set; } = 0;
    public (string, float) Product { get; set; } = ("Meat", 0);
    public List<(string, int)> ConsumeProducts { get; set; } = new List<(string, int)>() { ("money", 0) };
    public void AddCitizen(int n)
    {
        countOfCitizens += n;
    }
    public void RemoveCitizen(int n)
    {
        countOfCitizens -= n;
    }
    public bool CanCitizenBeAdded()
    {
        return countOfCitizens < 6;
    }
    public Farm()
    {
        name = "Farm";
        Length = 5;
        Width = 8;
        woodToBuild = 20;
        moneyToBuild = 2000;
        toolToBuild = 10;
    }
    public override string SetInformation()
    {
        string s = "Name: " + name + "\nProduct: " + Product.Item1 + " " + Product.Item2;
        foreach (var x in ConsumeProducts)
        {
            s += "\nConsume product: " + x.Item2 + " " + x.Item1;
        }
        return s;
    }
    public void Produce()
    {
        Product = (Product.Item1, Productivity * 4);
        city.meat += Product.Item2 * Time.deltaTime / 5;
    }
    public void Consume()
    {
        Productivity = (int)Math.Min(countOfCitizens * 30, city.money) / 30;
        ConsumeProducts[0] = (ConsumeProducts[0].Item1, Productivity * 30);
        city.money -= ConsumeProducts[0].Item2 * Time.deltaTime / 5;
    }
}


public class TownHall : Building
{
    public TownHall()
    {
        name = "Town Hall";
        Length = 4;
        Width = 4;
    }
    public void CreateObject(Vector3 position)
    {
        model = Instantiate(modelList.dictionary[name], modelList.dictionary[name].transform.position + new Vector3(530, 0, 530), modelList.dictionary[name].transform.rotation);
        model.transform.parent = gameObject.transform;
        city = modelList.gameObject.GetComponent<City>();
    }
    public override string SetInformation()
    {
        return ("Name: " + name);
    }
}


public class Manufactory : Building, IProductiveBuilding
{
    public int countOfCitizens { get; set; }
    public int Productivity { get; set; } = 0;
    public (string, float) Product { get; set; } = ("Tools", 0);
    public List<(string, int)> ConsumeProducts { get; set; } = new List<(string, int)>() { ("money", 0), ("wood", 0) };
    public void AddCitizen(int n)
    {
        countOfCitizens += n;
    }
    public void RemoveCitizen(int n)
    {
        countOfCitizens -= n;
    }
    public bool CanCitizenBeAdded()
    {
        return countOfCitizens < 3;
    }
    public Manufactory()
    {
        name = "Manufactory";
        Length = 3;
        Width = 3;
        woodToBuild = 20;
        moneyToBuild = 2000;
    }
    public override string SetInformation()
    {
        string s = "Name: " + name + "\nProduct: " + Product.Item1 + " " + Product.Item2;
        foreach (var x in ConsumeProducts)
        {
            s += "\nConsume product: " + x.Item2 + " " + x.Item1;
        }
        return s;
    }
    public void Produce()
    {
        Product = (Product.Item1, Productivity * 2);
        city.tools += Product.Item2 * Time.deltaTime / 5;
    }
    public void Consume()
    {
        Productivity = (int)Math.Min(countOfCitizens * 15, city.money) / 15;
        Productivity = (int)Math.Min(Math.Min(countOfCitizens, city.wood), Productivity);
        ConsumeProducts[0] = (ConsumeProducts[0].Item1, Productivity * 15);
        ConsumeProducts[1] = (ConsumeProducts[1].Item1, Productivity * 4);
        city.money -= ConsumeProducts[0].Item2 * Time.deltaTime / 5;
        city.wood -= ConsumeProducts[1].Item2 * Time.deltaTime / 5;
    }
}


public class ClothesManufactory: Building, Upgradable, IProductiveBuilding
{
    public int countOfCitizens { get; set; }
    public int Productivity { get; set; } = 0;
    public (string, float) Product { get; set; } = ("Clothes", 0);
    public List<(string, int)> ConsumeProducts { get; set; } = new List<(string, int)>() { ("money", 0) };
    public void AddCitizen(int n)
    {
        countOfCitizens += n;
    }
    public void RemoveCitizen(int n)
    {
        countOfCitizens -= n;
    }
    public bool CanCitizenBeAdded()
    {
        return countOfCitizens < 4;
    }
    public int Level { get; set; } = 1;
    public ClothesManufactory()
    {
        name = "Clothes Manufactory";
        Length = 2;
        Width = 2;
        woodToBuild = 15;
        moneyToBuild = 1500;
    }
    public void Upgrade()
    {
        Vector3 positiion = model.transform.position;
        Destroy(model);
        model = Instantiate(modelList.dictionary[name + "2"], new Vector3(positiion.x, 0f, positiion.z), new Quaternion());
        model.transform.parent = gameObject.transform;
        city.wood -= 15;
        city.money -= 1000;
        Level++;
        Debug.Log(Level);
    }
    public bool CanBeUpgraded()
    {
        return (Level < 2) && (city.wood > 15) && (city.money > 1000);
    }
    public override string SetInformation()
    {
        string s = "Name: " + name + "\nProduct: " + Product.Item1 + " " + Product.Item2;
        foreach (var x in ConsumeProducts)
        {
            s += "\nConsume product: " + x.Item2 + " " + x.Item1;
        }
        return s;
    }
    public void Produce()
    {
        Product = (Product.Item1, ((float)Level +1f)/2f * Productivity * 4f);
        city.clothes += Product.Item2 * Time.deltaTime / 5;
    }
    public void Consume()
    {
        Productivity = (int)Math.Min(countOfCitizens * 20, city.money) / 20;
        ConsumeProducts[0] = (ConsumeProducts[0].Item1, Productivity * 20);
        city.money -= ConsumeProducts[0].Item2 * Time.deltaTime / 5;
    }
}


public class LuxiriousManufactory : Building, IProductiveBuilding
{
    public int countOfCitizens { get; set; }
    public int Productivity { get; set; } = 0;
    public (string, float) Product { get; set; } = ("Luxirious", 0);
    public List<(string, int)> ConsumeProducts { get; set; } = new List<(string, int)>() { ("money", 0), ("tools", 0) };
    public void AddCitizen(int n)
    {
        countOfCitizens += n;
    }
    public void RemoveCitizen(int n)
    {
        countOfCitizens -= n;
    }
    public bool CanCitizenBeAdded()
    {
        return countOfCitizens < 4;
    }
    public LuxiriousManufactory()
    {
        name = "Luxirious Manufactory";
        Length = 6;
        Width = 6;
        woodToBuild = 30;
        moneyToBuild = 3000;
        toolToBuild = 20;
    }
    public override string SetInformation()
    {
        string s = "Name: " + name + "\nProduct: " + Product.Item1 + " " + Product.Item2;
        foreach (var x in ConsumeProducts)
        {
            s += "\nConsume product: " + x.Item2 + " " + x.Item1;
        }
        return s;
    }
    public void Produce()
    {
        Product = (Product.Item1, Productivity * 2);
        city.luxirious += Product.Item2 * Time.deltaTime / 5;
    }
    public void Consume()
    {
        Productivity = (int)Math.Min(countOfCitizens * 40, city.money) / 40;
        Productivity = (int)Math.Min(Math.Min(countOfCitizens, city.tools), Productivity);
        ConsumeProducts[0] = (ConsumeProducts[0].Item1, Productivity * 40);
        ConsumeProducts[1] = (ConsumeProducts[1].Item1, Productivity);
        city.money -= ConsumeProducts[0].Item2 * Time.deltaTime / 5;
        city.tools -= ConsumeProducts[1].Item2 * Time.deltaTime / 5;
    }
}




public class BuildingTest
{
    public bool BuildTest()
    {
        WindMill wm = new WindMill();
        Woods wood = new Woods();
        return (wm.name == "Wind Mill" && wm.Level == 1 && wood.name == "Woods");
    }
    public bool AddCitizenTest()
    {
        Manufactory manufactory = new Manufactory();
        if (!manufactory.CanCitizenBeAdded()) return false;
        manufactory.AddCitizen(3);
        if (manufactory.CanCitizenBeAdded()) return false;
        return true;
    }
    public bool RemoveCitizenTest()
    {
        Manufactory manufactory = new Manufactory();
        manufactory.AddCitizen(3);
        if (manufactory.countOfCitizens != 3) return false;
        manufactory.RemoveCitizen(3);
        if (manufactory.countOfCitizens > 0) return false;
        return true;
    }
    public bool UpgradeTest()
    {
        City city = new City();
        ClothesManufactory clothes = new ClothesManufactory();
        clothes.city = city;
        if (clothes.CanBeUpgraded()) return false;
        city.wood = 100;
        city.money = 10000;
        city.tools = 100;
        if (!clothes.CanBeUpgraded()) return false;
        return true;
    }
    public bool ProductiveTest()
    {
        WindMill wind = new WindMill();
        if (wind.ConsumeProducts[0].Item1 != "money" || wind.Product.Item1 != "Bread") return false;
        return true;
    }
    public bool AllTest()
    {
        return BuildTest() && AddCitizenTest() && UpgradeTest() && ProductiveTest() && RemoveCitizenTest();
    }
    
}