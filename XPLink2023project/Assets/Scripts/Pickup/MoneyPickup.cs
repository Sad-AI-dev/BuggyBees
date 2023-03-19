using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class MoneyPickup : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("Player")) {
            MoneyManager.instance.GainMoney(value);
            AudioManager.instance.PlayOneShot("PickUp");
            Destroy(gameObject);
        }
    }
}
