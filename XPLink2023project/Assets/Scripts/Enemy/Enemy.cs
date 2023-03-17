using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [System.Serializable]
    public class Stats {
        public float moveSpeed = 1f;
        public float damage = 1f;
        public int heldMoney = 1;
    }
    public Stats stats;

    //external components
    private Rigidbody2D rb;
    //vars
    private Transform targetPoint;
    [HideInInspector] public Action<Enemy> onEnemyDestroy;

    private void Start()
    {
        targetPoint = PathManager.instance.centerPoint;
        transform.rotation = LookAt2D.LookAtTransform(transform, targetPoint);
        //get rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = (targetPoint.position - transform.position).normalized * (stats.moveSpeed * 100 * Time.deltaTime);
    }

    //===================== Handle Death =================
    //handle hitting centerpoint
    public void DestroyEnemy()
    {
        onEnemyDestroy?.Invoke(this);
        Destroy(gameObject);
    }

    public void KillEnemy()
    {
        MoneyManager.instance.GainMoney(stats.heldMoney);
    }

    //==================== Custom Sort ===================
    public int ProgressSort(Enemy other)
    {
        return (targetPoint.position - transform.position).magnitude.CompareTo((targetPoint.position - other.transform.position).magnitude);
    }
}
