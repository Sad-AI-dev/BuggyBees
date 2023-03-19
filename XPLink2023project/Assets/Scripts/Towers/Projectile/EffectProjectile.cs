using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DevKit;

public class EffectProjectile : MonoBehaviour
{
    [HideInInspector] public float targetSize;
    [HideInInspector] public float damage;
    [SerializeField] private float growSpeed = 1f;

    [SerializeField] private UnityEvent<HealthManager> onFindEnemy;

    private void FixedUpdate()
    {
        Grow();
    }

    private void Grow()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetSize, targetSize, 1), growSpeed * Time.deltaTime);
        //lifeTime
        if (Mathf.Abs(transform.localScale.x - targetSize) < 0.1f) { Destroy(gameObject); }
    }

    //=========== enemy detection =================
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            onFindEnemy?.Invoke(collision.GetComponent<HealthManager>());
        }
    }

    //============== on hit enemy ==============
    public void DealDamage(HealthManager target)
    {
        target.TakeDamage(damage);
    }
}
