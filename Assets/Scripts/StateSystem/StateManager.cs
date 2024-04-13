using System;
using UnityEngine;


public class StateManager : MonoBehaviour
{
    private CameraFollow playerCam;

    private void Awake()
    {
        EventManager.ResetManager();
        EventManager.eventOnStateUpdate += CheckIncident;
    }

    private void Start() => playerCam = Camera.main.GetComponent<CameraFollow>();

    private void CheckIncident(string incident)
    {
        switch (incident) 
        {
            case "EatFood":
                playerCam.Zoom();
                Debug.Log(playerCam.ToString());
                break;
            case "Death":
                              
                break;
            case "foodGenerated":
                
                break;
        }
    }
}
