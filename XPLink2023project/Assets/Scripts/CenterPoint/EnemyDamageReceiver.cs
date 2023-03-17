using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamageReceiver : MonoBehaviour
{
    public UnityEvent<float> onRecieveEnemyDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            Enemy e = collision.GetComponent<Enemy>();
            onRecieveEnemyDamage?.Invoke(e.stats.damage);
            e.DestroyEnemy();
        }
    }
}
