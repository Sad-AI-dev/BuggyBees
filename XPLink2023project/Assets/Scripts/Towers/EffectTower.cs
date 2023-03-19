using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTower : Tower
{
    [SerializeField] private GameObject proj;

    protected override void SortTargets() { }

    protected override void Activate()
    {
        GameObject gO = Instantiate(proj);
        gO.transform.position = transform.position;
        EffectProjectile effectProj = gO.GetComponent<EffectProjectile>();
        effectProj.targetSize = stats.range * 2;
        effectProj.damage = stats.damage;
    }
}
