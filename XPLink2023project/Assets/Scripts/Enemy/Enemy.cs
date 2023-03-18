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
    private List<Transform> path;
    public int targetIndex { get; private set; }

    [HideInInspector] public Action<Enemy> onEnemyDestroy;

    private void Start()
    {
        path = PathManager.instance.path;
        //get rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //UpdateRotation();
        Move();
    }

    private void UpdateRotation()
    {
        transform.rotation = LookAt2D.LookAtTransform(transform, path[targetIndex]);
        if (transform.position.x > path[targetIndex].position.x) {
            transform.Rotate(new Vector3(0, 0, 180f));
        }
    }
    private void Move()
    {
        Vector3 diff = path[targetIndex].position - transform.position;
        rb.velocity = diff.normalized * (stats.moveSpeed * 100 * Time.deltaTime);
        if (diff.magnitude < 0.1f) {
            OnReachPoint();
        }
    }
    //================= Handle Reach End ===============
    private void OnReachPoint()
    {
        transform.position = path[targetIndex].position;
        if (targetIndex < path.Count) {
            targetIndex++;
        }
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
        if (other.targetIndex == targetIndex) {
            Vector3 pathPoint = path[targetIndex].position;
            return (pathPoint - transform.position).magnitude.CompareTo((pathPoint - other.transform.position).magnitude);
        }
        else {
            return targetIndex.CompareTo(other.targetIndex);
        }
    }
}
