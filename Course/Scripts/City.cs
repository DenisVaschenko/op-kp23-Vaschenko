using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    public float bread;
    public float meat;
    public float clothes;
    public float money;
    public float wood;
    public float tools;
    public float luxirious;
    List<Building> buildings = new List<Building>();
    int freeRichCitizens = 0;
    int richCitizens = 0;
    int freePeasants = 0;
    int peasants = 0;
    public int Peasants { get { return peasants; } }
    public int RichCitizen { get { return richCitizens; } }
    public Building[,] matrix = new Building[1001, 1001];
    public GameObject Ui;
    private void Start()
    {
        BuildingTest buildingTest = new BuildingTest();
        CityTest cityTest = new CityTest();
        if (buildingTest.AllTest() && cityTest.AllTest()) Debug.Log("All unit tests were completed");
        else Debug.Log("Error!!!");
    }
    private void FixedUpdate()
    {
        if (Input.GetKey("t"))
        {
            money += 100;
            wood += 100;
            tools += 100;
        }
        foreach (Building building in buildings)
        {
            if (building as IProductiveBuilding != null) (building as IProductiveBuilding).Produce();
        }
        money += 50 * Time.deltaTime / 5;
        wood += 5 * Time.deltaTime / 5;
        foreach (Building building in buildings)
        {
            if (building as IProductiveBuilding != null) (building as IProductiveBuilding).Consume();
        }
        foreach (Building x in buildings)
        {
            if (x as IProductiveBuilding != null && (x as IProductiveBuilding).CanCitizenBeAdded())
            {
                if (((x as Manufactory) != null || (x as LuxiriousManufactory) != null) && (freeRichCitizens > 0))
                {
                    (x as IProductiveBuilding).AddCitizen(1);
                    freeRichCitizens--;
                }
                else if ((freePeasants > 0) && ((x as Manufactory) == null && (x as LuxiriousManufactory) == null))
                {
                    (x as IProductiveBuilding).AddCitizen(1);
                    freePeasants--;
                }
            }
        }
        money += (Mathf.Min(bread, richCitizens * 0.75f) * 5f + Mathf.Min(clothes, richCitizens * 1f) * 8f + Mathf.Min(meat, richCitizens * 1f) * 13f + Mathf.Min(meat, richCitizens * 1f) * 13f + Mathf.Min(luxirious, richCitizens * 1f) * 50f) * Time.deltaTime / 5;
        bread -= Mathf.Min(bread, richCitizens * 0.75f) * Time.deltaTime / 5;
        clothes -= Mathf.Min(clothes, richCitizens * 1f) * Time.deltaTime / 5;
        meat -= Mathf.Min(meat, richCitizens * 1f) * Time.deltaTime / 5;
        luxirious -= Mathf.Min(luxirious, richCitizens * 0.5f) * Time.deltaTime / 5;
        money += (Mathf.Min(bread, peasants * 1f) * 5f + Mathf.Min(clothes, peasants * 0.5f) * 8f) * Time.deltaTime / 5;
        bread -= Mathf.Min(bread, peasants * 1f) * Time.deltaTime / 5;
        clothes -= Mathf.Min(clothes, peasants * 0.5f) * Time.deltaTime / 5;
        if (tools > 100)
        {
            money += (tools - 100) * 6f * Time.deltaTime / 5;
            tools -= (tools - 100) * Time.deltaTime / 5;
        }
        if (wood > 100)
        {
            money += (wood - 100) * 2f * Time.deltaTime / 5;
            wood -= (wood - 100) * Time.deltaTime / 5;
        }
        Ui.GetComponent<Text>().text = (" money: " + money + "\nbread: " + bread + "\nmeat: " + meat + "\nclothes: " + clothes + "\nwood: " + wood + "\ntools: " + tools + "\nluxirious: " + luxirious +
            "\nFree Peasant: " + freePeasants + "\nFree Rich Citizens: " + freeRichCitizens);
    }
    public void AddBuilding(Building building)
    {
        buildings.Add(building);
    }
    public bool CanBeBuilt(Building building)
    {
        if (building.woodToBuild > wood || building.toolToBuild > tools || building.moneyToBuild > money) return false; 
        if ((building as Resource) != null && !(building as Resource).CheckNearbyBuildings()) return false;
        int x = (int)building.model.transform.position.x;
        int y = (int)building.model.transform.position.z;
        if (x < building.Length || x > 1000 - building.Length || y < building.Width || y > 1000 - building.Width) return false;
        for (int i = x - building.Length; i <= x + building.Length; i++)
        {
            for (int j = y - building.Width; j <= y + building.Width; j++)
            {
                if (matrix[i,j] != null) return false;
            }
        }
        return true;
    }
    public void Build(Building building)
    {
        int x = (int)building.model.transform.position.x;
        int y = (int)building.model.transform.position.z;
        for (int i = x - building.Length; i <= x + building.Length; i++)
        {
            for (int j = y - building.Width; j <= y + building.Width; j++)
            {
                matrix[i,j] = building;
            }
        }
        AddBuilding(building);
        money -= building.moneyToBuild;
        wood -= building.woodToBuild;
        tools -= building.toolToBuild;
    }
    public void ConvertCitizens(int n)
    {
        peasants -= n;
        richCitizens += n;
        freeRichCitizens += n;
        if (freePeasants >= n)
        {
            freePeasants -= n;
        }
        else
        {
            int res = n-freePeasants;
            freePeasants = 0;
            int i = 0;
            foreach (Building x in buildings)
            {
                if (x as IProductiveBuilding != null && (x as IProductiveBuilding).countOfCitizens > 0 && ((x as Manufactory) == null && (x as LuxiriousManufactory) == null))
                {
                    i = Mathf.Min(res, (x as IProductiveBuilding).countOfCitizens);
                    res -= i;
                    (x as IProductiveBuilding).RemoveCitizen(i);
                    if (res == null) break;
                }
            }
        }
    }
    public void AddCitizens(int n)
    {
        peasants += n;
        freePeasants += n;
    }
}


public class CityTest
{
    public bool ConstrutorTest()
    {
        try
        {
            City city = new City();
            if (city.bread != 0 || city.meat != 0 || city.clothes != 0) return false;
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool AddCitizensTest()
    {
        City city = new City();
        city.AddCitizens(5);
        return city.Peasants == 5;
    }
    public bool ConvertCitizenTest()
    {
        City city = new City();
        city.AddCitizens(8);
        city.ConvertCitizens(5);
        return city.Peasants == 3 && city.RichCitizen == 5;
    }
    public bool AllTest()
    {
        return ConstrutorTest() && AddCitizensTest() && ConvertCitizenTest();
    }
}
