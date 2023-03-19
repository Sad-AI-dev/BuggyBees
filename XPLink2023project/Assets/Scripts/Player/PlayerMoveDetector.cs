using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveDetector : MonoBehaviour
{
    public bool isMoving;
    private Vector3 lastPos;

    private void Start()
    {
        lastPos = transform.position;
    }

    private void LateUpdate()
    {
        isMoving = Vector3.Distance(lastPos, transform.position) > 0.01f;
        lastPos = transform.position;
    }
}
