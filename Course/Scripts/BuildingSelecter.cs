using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BuildingSelecter : MonoBehaviour
{
    public Camera cam;
    public LayerMask layerMask;
    public GameObject Ui;
    public GameObject Button;
    Building currBuilding;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit raycastHit, 1000f, layerMask);
            if (raycastHit.collider != null) Select(raycastHit.collider.transform.parent.gameObject.GetComponent<Building>());
        }
    }
    private void Select(Building building)
    {
        Ui.GetComponent<Text>().text = building.SetInformation();
        currBuilding = building;
        if (building as Upgradable != null && (building as Upgradable).Level < 2) Button.SetActive(true);
        else Button.SetActive(false);
    }
    public void UpgradeCurrBuilding()
    {
        if ((currBuilding as Upgradable).CanBeUpgraded())(currBuilding as Upgradable).Upgrade();
        Select (currBuilding);
    }
}
