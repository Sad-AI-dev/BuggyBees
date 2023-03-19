using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class MoneyTower : Tower
{
    [SerializeField] private int moneyToGenerate;

    protected override void SortTargets() { }

    protected override void Activate()
    {
        MoneyManager.instance.GainMoney(moneyToGenerate);
        AudioManager.instance.PlayOneShot("Shoot");
    }
}
