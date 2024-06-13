using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new(0f,0f,-10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        var targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
