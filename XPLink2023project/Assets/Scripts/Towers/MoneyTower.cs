using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class MoneyTower : Tower
{
    [SerializeField] private int moneyToGenerate;

    private void Start()
    {
        StartCoroutine(GenerateCo());
    }
    private IEnumerator GenerateCo()
    {
        yield return new WaitForSeconds(60f / stats.attackSpeed);
        MoneyManager.instance.GainMoney(moneyToGenerate);
        AudioManager.instance.PlayOneShot("Shoot");
        StartCoroutine(GenerateCo());
    }

    protected override void SortTargets() { }

    protected override void Activate() { }
}
