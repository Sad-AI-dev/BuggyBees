using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class EffectTower : Tower
{
    [SerializeField] private GameObject proj;

    protected override void SortTargets() { }

    protected override void Activate()
    {
        GameObject gO = Instantiate(proj);
        AudioManager.instance.PlayOneShot("Shoot");
        gO.transform.position = transform.position;
        EffectProjectile effectProj = gO.GetComponent<EffectProjectile>();
        effectProj.targetSize = stats.range * 2;
        effectProj.damage = stats.damage;
    }
}
