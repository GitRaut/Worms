using System;
using Unity.Netcode;
using UnityEngine;


public class StateManager : NetworkBehaviour
{
    private CameraZoom playerCam;

    private void Awake()
    {
        EventManager.ResetManager();
        EventManager.eventOnStateUpdate += CheckIncident;
    }

    public override void OnNetworkSpawn() => Init();

    private void Init() => playerCam = Camera.main.GetComponent<CameraZoom>();

    private void CheckIncident(string incident)
    {
        switch (incident) 
        {
            case "CameraZoom":
                playerCam.Zoom();
                break;
            case "CameraReZoom":
                playerCam.ReZoom();
                break;
            case "Death":
               
                break;
            case "foodGenerated":
                
                break;
        }
    }
}
