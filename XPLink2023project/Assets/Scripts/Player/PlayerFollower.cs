using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lookAheadMult;
    [SerializeField] private Rigidbody2D playerbody;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 targetPos = playerbody.position + (playerbody.velocity * lookAheadMult);
        transform.position = Vector3.Lerp(transform.position, new Vector3 (targetPos.x, targetPos.y, transform.position.z), moveSpeed * Time.deltaTime);
    }
}
