using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementManager : MonoBehaviour
{
    private void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
    public static PlacementManager instance;

    public PlacePreview preview;
    public GameObject currentSelected;

    private void Start()
    {
        preview.gameObject.SetActive(false);
    }

    public void SetSelected(GameObject toSelect)
    {
        currentSelected = toSelect;
        if (!preview.gameObject.activeSelf) {
            preview.gameObject.SetActive(true);
        }
    }
    public void RemoveSelected()
    {
        currentSelected = null;
        preview.gameObject.SetActive(false);
    }

    //============= attempt place ==================
    private void Update()
    {
        if (currentSelected) {
            if (Input.GetMouseButtonDown(0) && preview.IsValid && !EventSystem.current.IsPointerOverGameObject()) {
                preview.gameObject.SetActive(false);
                //build tower
                BuildTower();
            }
            else if (Input.GetKeyDown(KeyCode.Escape)) {
                RemoveSelected();
            }
        }
    }

    private void BuildTower()
    {
        GameObject tower = Instantiate(currentSelected);
        tower.transform.position = preview.transform.position;
        //pay
        MoneyManager.instance.PayMoney(tower.GetComponent<Tower>().stats.price);
        RemoveSelected();
    }
}
