using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveDetector : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public bool isMoving;

    private void LateUpdate()
    {
        isMoving = rb.velocity.magnitude > 0.1f;

        animator.SetBool("isWalking", isMoving);
    }
}
