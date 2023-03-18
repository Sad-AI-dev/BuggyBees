using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelectable : Selectable
{
    //external components
    private Tower tower;

    private void Start()
    {
        tower = GetComponent<Tower>();
        base.Start();
    }

    public override void BeginHover()
    {
        base.BeginHover();
        if (!selected) {
            tower.ShowTowerRange();
        }
    }

    public override void EndHover()
    {
        base.EndHover();
        if (!selected) {
            tower.HideTowerRange();
        }
    }

    public override void BeginSelect()
    {
        base.BeginSelect();
        tower.ShowTowerRange();
    }

    public override void EndSelect()
    {
        base.EndSelect();
        tower.HideTowerRange();
    }
}
