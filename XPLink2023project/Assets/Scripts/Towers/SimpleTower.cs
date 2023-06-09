using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class SimpleTower : Tower
{
    [SerializeField] private GameObject projPrefab;

    protected override void SortTargets()
    {
        enemiesInRange.Sort((Enemy e1, Enemy e2) => e1.ProgressSort(e2));
    }

    protected override void Activate()
    {
        GameObject gO = Instantiate(projPrefab);
        AudioManager.instance.PlayOneShot("Shoot");
        gO.GetComponent<Projectile>().SetupTarget(enemiesInRange[0]);
        gO.transform.position = transform.position;
    }
}
