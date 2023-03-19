using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class Slower : MonoBehaviour
{
    [SerializeField] private float slowPercent = 0.5f;
    [SerializeField] private float slowTime = 2f;

    public void SlowEnemy(HealthManager target)
    {
        Enemy e = target.GetComponent<Enemy>();
        if (!e.slowed) {
            StartCoroutine(SlowCo(e));
        }
    }

    private IEnumerator SlowCo(Enemy target)
    {
        float takenSpeed = target.stats.moveSpeed * (1 - slowPercent);
        target.stats.moveSpeed -= takenSpeed;
        target.slowed = true;
        //wait
        yield return new WaitForSeconds(slowTime);
        //unslow
        if (target) { 
            target.stats.moveSpeed += takenSpeed;
            target.slowed = false;
        }
    }
}
