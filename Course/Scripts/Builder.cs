using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class Builder : MonoBehaviour
{
    City city;
    GameObject currObject;
    public Camera camera;
    Material originalMaterial;
    public Material Green;
    public Material Red;
    public LayerMask Ignore;
    bool f = false;
    private void Start()
    {
        city = gameObject.GetComponent<City>();
        
    }
    public void BuildWindMill()
    {
        if (currObject == null)
        {
            currObject = new GameObject();
            currObject.AddComponent<WindMill>().modelList = gameObject.GetComponent<ModelList>();
            currObject.GetComponent<WindMill>().CreateObject();
            originalMaterial = currObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        }
    }
    public void BuildHouse()
    {
        if (currObject == null)
        {
            currObject = new GameObject();
            currObject.AddComponent<House>().modelList = gameObject.GetComponent<ModelList>();
            currObject.GetComponent<House>().CreateObject();
            originalMaterial = currObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        }
    }
    public void BuildSawMill()
    {
        if (currObject == null)
        {
            currObject = new GameObject();
            currObject.AddComponent<SawMill>().modelList = gameObject.GetComponent<ModelList>();
            currObject.GetComponent<SawMill>().CreateObject();
            originalMaterial = currObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        }
    }
    public void BuildWheat()
    {
        if (currObject == null)
        {
            currObject = new GameObject();
            currObject.AddComponent<Wheat>().modelList = gameObject.GetComponent<ModelList>();
            currObject.GetComponent<Wheat>().CreateObject();
            originalMaterial = currObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        }
    }
    public void BuildWoods()
    {
        if (currObject == null)
        {
            currObject = new GameObject();
            currObject.AddComponent<Woods>().modelList = gameObject.GetComponent<ModelList>();
            currObject.GetComponent<Woods>().CreateObject();
            originalMaterial = currObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        }
    }
    public void BuildFarm()
    {
        if (currObject == null)
        {
            currObject = new GameObject();
            currObject.AddComponent<Farm>().modelList = gameObject.GetComponent<ModelList>();
            currObject.GetComponent<Farm>().CreateObject();
            originalMaterial = currObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        }
    }
    public void BuildTownHall()
    {
        currObject = new GameObject();
        currObject.AddComponent<TownHall>().modelList = gameObject.GetComponent<ModelList>();
        currObject.GetComponent<TownHall>().CreateObject(new Vector3(530, 0, 530));
        city.Build(currObject.GetComponent<Building>());
        currObject = null;
        f = true;
    }
    public void BuildManufactory()
    {
        if (currObject == null)
        {
            currObject = new GameObject();
            currObject.AddComponent<Manufactory>().modelList = gameObject.GetComponent<ModelList>();
            currObject.GetComponent<Manufactory>().CreateObject();
            originalMaterial = currObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        }
    }
    public void BuildClothesManufactory()
    {
        if (currObject == null)
        {
            currObject = new GameObject();
            currObject.AddComponent<ClothesManufactory>().modelList = gameObject.GetComponent<ModelList>();
            currObject.GetComponent<ClothesManufactory>().CreateObject();
            originalMaterial = currObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        }
    }
    public void BuildLuxiriousManufactory()
    {
        if (currObject == null)
        {
            currObject = new GameObject();
            currObject.AddComponent<LuxiriousManufactory>().modelList = gameObject.GetComponent<ModelList>();
            currObject.GetComponent<LuxiriousManufactory>().CreateObject();
            originalMaterial = currObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().material;
        }
    }
    public void Update()
    {
        if (!f) BuildTownHall();
        if (currObject != null)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit raycastHit, 1000f, ~Ignore);
            currObject.GetComponent<Building>().MoveObject(raycastHit.point);
            if (city.CanBeBuilt(currObject.GetComponent<Building>())) currObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = Green;
            else currObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = Red;
            if (Input.GetMouseButton(0) && city.CanBeBuilt(currObject.GetComponent<Building>()))
            {
                if (currObject.GetComponent<Building>() as Resource != null) (currObject.GetComponent<Building>() as Resource).SetParent();
                currObject.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = originalMaterial;
                city.Build(currObject.GetComponent<Building>());
                if (currObject.GetComponent<Building>() as House != null) (currObject.GetComponent<Building>() as House).AddCitizen(4);
                currObject = null;
            }
            else if (Input.GetMouseButton(1))
            {
                Destroy(currObject);
                currObject = null;
            }
        }
        
    }
}
