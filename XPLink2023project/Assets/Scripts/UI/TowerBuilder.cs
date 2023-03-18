using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public void BuildTower(GameObject toBuild)
    {
        Selectable currentSelect = ClickManager.instance.currentSelected;
        GameObject tower = Instantiate(toBuild);
        tower.transform.position = currentSelect.transform.position;
        //pay
        MoneyManager.instance.PayMoney(tower.GetComponent<Tower>().stats.price);
        //destroy current select + unselect
        ClickManager.instance.SetSelected(null);
        Destroy(currentSelect.gameObject);
    }
}
