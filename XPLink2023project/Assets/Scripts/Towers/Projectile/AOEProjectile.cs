using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class AOEProjectile : Projectile
{
    [SerializeField] protected float damageRange;
    [SerializeField] protected LayerMask damageMask;

    protected override void OnHitEnemy(Collider2D collision)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, damageRange, damageMask);
        foreach (Collider2D hit in hits) {
            if (hit.CompareTag("Enemy")) {
                hit.GetComponent<HealthManager>().TakeDamage(damage);
            }
        }
    }
}
