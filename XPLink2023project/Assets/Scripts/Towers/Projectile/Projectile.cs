using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float damage = 1f;

    private Enemy target;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetupTarget(Enemy e)
    {
        target = e;
        e.onEnemyDestroy += OnEnemyDestroy;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = (target.transform.position - transform.position).normalized * (moveSpeed * 100 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            target.onEnemyDestroy -= OnEnemyDestroy;
            collision.GetComponent<HealthManager>().TakeDamage(damage);
            StartCoroutine(DestroyCo());
        }
    }
    private IEnumerator DestroyCo()
    {
        yield return null;
        Destroy(gameObject);
    }

    //============ handle enemy death ================
    private void OnEnemyDestroy(Enemy e)
    {
        Destroy(gameObject); // remove redundant projectiles
    }
}
