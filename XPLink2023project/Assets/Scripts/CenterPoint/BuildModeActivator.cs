using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModeActivator : MonoBehaviour
{
    private PlayerFollower camMover;

    private void Start()
    {
        camMover = Camera.main.GetComponent<PlayerFollower>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) {
            camMover.followPlayerMode = false;
            UIManager.instance.ToggleVisibility();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) {
            camMover.followPlayerMode = true;
            UIManager.instance.ToggleVisibility();
            PlacementManager.instance.RemoveSelected();
        }
    }
}
