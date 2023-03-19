using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lookAheadMult;
    [SerializeField] private Rigidbody2D playerbody;

    public bool followPlayerMode = true;
    [Header("overview mode")]
    [SerializeField] private float overviewMoveSpeed;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private Vector2 targetZoomPos;
    [SerializeField] private float targetZoom;

    private Camera cam;
    private float startZoom;

    private void Start()
    {
        cam = GetComponent<Camera>();
        startZoom = cam.orthographicSize;
    }

    private void FixedUpdate()
    {
        if (followPlayerMode) { Move(); }
        else { MoveToOverview(); }
    }

    private void Move()
    {
        Vector3 targetPos = playerbody.position + (playerbody.velocity * lookAheadMult);
        transform.position = Vector3.Lerp(transform.position, new Vector3 (targetPos.x, targetPos.y, transform.position.z), moveSpeed * Time.deltaTime);
        //adjust zoom
        if (cam.orthographicSize > startZoom) {
            cam.orthographicSize -= zoomSpeed * Time.deltaTime;
        }
    }
    private void MoveToOverview()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetZoomPos.x, targetZoomPos.y, transform.position.z), overviewMoveSpeed * Time.deltaTime);
        //adjust zoom
        if (cam.orthographicSize < targetZoom) {
            cam.orthographicSize += zoomSpeed * Time.deltaTime;
        }
    }
}
