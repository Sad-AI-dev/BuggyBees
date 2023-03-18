using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected float damage = 1f;

    private Enemy target;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetupTarget(Enemy e)
    {
        target = e;
    }

    //============ movement ===============
    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (target != null) {
            rb.velocity = (target.transform.position - transform.position).normalized * (moveSpeed * 100 * Time.deltaTime);
        }
    }

    //=============== handle collision ================
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            OnHitEnemy(collision);
            HandleEnemyHit();
        }
    }
    protected virtual void OnHitEnemy(Collider2D collision)
    {
        collision.GetComponent<HealthManager>().TakeDamage(damage);
    }
    private void HandleEnemyHit()
    {
        StartCoroutine(DestroyCo());
    }
    protected IEnumerator DestroyCo()
    {
        yield return null;
        Destroy(gameObject);
    }
}
