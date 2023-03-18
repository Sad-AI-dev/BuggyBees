using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRangeShower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower") && !collision.isTrigger) {
            collision.GetComponent<Tower>().ShowTowerRange();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower") && !collision.isTrigger) {
            collision.GetComponent<Tower>().HideTowerRange();
        }
    }
}
