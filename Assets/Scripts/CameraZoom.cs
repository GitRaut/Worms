using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CameraZoom : NetworkBehaviour
{
    [Header("ZoomSettings")]
    [SerializeField] private float zoomScale;
    [SerializeField] private float zoomSpeed;

    private Camera mainCam;

    public override void OnNetworkSpawn() => Init();

    private void Init() => mainCam = Camera.main;

    public void Zoom() => mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, mainCam.orthographicSize + zoomScale, zoomSpeed);
    public void ReZoom() => mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, mainCam.orthographicSize - zoomScale, zoomSpeed);
}
