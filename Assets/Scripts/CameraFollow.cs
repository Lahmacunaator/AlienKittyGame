using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new(0f,0f,-10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    private float initialY = 0;

    [SerializeField] private Transform target;

    private void Awake()
    {
        initialY = transform.position.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var targetPos = new Vector3(target.position.x + offset.x, initialY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}