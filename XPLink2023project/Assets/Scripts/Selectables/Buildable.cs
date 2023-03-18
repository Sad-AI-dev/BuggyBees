using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : Selectable
{
    private void Start()
    {
        base.Initialize();
    }

    public override void BeginSelect()
    {
        base.BeginSelect();
        UIManager.instance.ShowBuildPanel();
    }

    public override void EndSelect()
    {
        base.EndSelect();
        UIManager.instance.HideBuildPanel();
    }
}
