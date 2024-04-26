using Unity.Netcode;
using UnityEngine;

public class CameraFollow : NetworkBehaviour
{
    [Header("FollowSettings")]
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    private Camera mainCam;

    private Vector3 targetPos;
    private Vector3 change;

    public override void OnNetworkSpawn() => Init();

    private void Init() => mainCam = Camera.main;

    private void FixedUpdate()
    {
        if (!IsOwner || !target) return;

        Move();
    }

    private void Move()
    {
        targetPos = new Vector3(target.position.x, target.position.y, mainCam.transform.position.z);
        mainCam.transform.position = Vector3.SmoothDamp(mainCam.transform.position, targetPos, ref change, speed);
    }
}
