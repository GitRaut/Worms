using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("FollowSettings")]
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    [Header("ZoomSettings")]
    [SerializeField] private float zoomScale;
    [SerializeField] private float zoomSpeed;

    private Camera mainCam;

    private Vector3 targetPos;
    private Vector3 change;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (!target) return;

        Move();
    }

    private void Move()
    {
        targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref change, speed);
    }

    public void Zoom() => mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, mainCam.orthographicSize + zoomScale, zoomSpeed);
}
