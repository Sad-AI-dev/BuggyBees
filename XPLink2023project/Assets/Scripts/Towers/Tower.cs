using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [System.Serializable]
    public class Stats {
        public int price = 1;
        public float range = 1f;
        public float damage = 1f;
        public float attackSpeed = 20f; //expressed in attack per minute
    }

    public Stats stats;

    //external components
    private CircleCollider2D coll;
    //vars
    protected List<Enemy> enemiesInRange;
    private Coroutine attackRoutine;

    private void Start()
    {
        coll = GetComponent<CircleCollider2D>();
        coll.radius = stats.range;
        enemiesInRange = new();
    }

    //============== Tower Activation ==============
    private IEnumerator AttackCo()
    {
        SortTargets();
        Activate();
        yield return new WaitForSeconds(60f / stats.attackSpeed);
        attackRoutine = StartCoroutine(AttackCo());
    }

    protected abstract void SortTargets();
    protected abstract void Activate(); //shoot / slow enemies / whatever

    //============== Enemy Detection ==============
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            Enemy e = collision.GetComponent<Enemy>();
            enemiesInRange.Add(e);
            e.onEnemyDestroy += OnEnemyDestroy;
            StartRoutineCheck();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            Enemy e = collision.GetComponent<Enemy>();
            enemiesInRange.Remove(e);
            e.onEnemyDestroy -= OnEnemyDestroy;
            StopRoutineCheck();
        }
    }

    private void OnEnemyDestroy(Enemy e)
    {
        enemiesInRange.Remove(e);
        StopRoutineCheck();
    }

    //============== Handle Routine ===============
    private void StartRoutineCheck()
    {
        if (enemiesInRange.Count == 1) { attackRoutine = StartCoroutine(AttackCo()); }
    }

    private void StopRoutineCheck()
    {
        if (enemiesInRange.Count == 0) { StopCoroutine(attackRoutine); }
    }
}
