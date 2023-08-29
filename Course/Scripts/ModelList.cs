using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ModelList: MonoBehaviour
{
    public GameObject WindMillModel;
    public GameObject WindMillModel2;
    public GameObject House;
    public GameObject House2;
    public GameObject SawMill;
    public GameObject Wheat;
    public GameObject Woods;
    public GameObject Farm;
    public GameObject TownHall;
    public GameObject Manufactory;
    public GameObject ClothesManufactory;
    public GameObject ClothesManufactory2;
    public GameObject LuxiriousManufactory;
    public Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();
    private void Start()
    {
        dictionary.Add("Wind Mill", WindMillModel);
        dictionary.Add("Wind Mill2", WindMillModel2);
        dictionary.Add("House", House);
        dictionary.Add("House2", House2);
        dictionary.Add("Saw Mill", SawMill);
        dictionary.Add("Wheat", Wheat);
        dictionary.Add("Woods", Woods);
        dictionary.Add("Farm", Farm);
        dictionary.Add("Town Hall", TownHall);
        dictionary.Add("Manufactory", Manufactory);
        dictionary.Add("Clothes Manufactory", ClothesManufactory);
        dictionary.Add("Clothes Manufactory2", ClothesManufactory2);
        dictionary.Add("Luxirious Manufactory", LuxiriousManufactory);
    }

}
