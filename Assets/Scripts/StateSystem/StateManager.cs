using System;
using UnityEngine;


public class StateManager : MonoBehaviour
{
    private void Awake()
    {
        EventManager.ResetManager();
        EventManager.eventOnStateUpdate += CheckIncident;
    }

    private void CheckIncident(string incident)
    {
        switch (incident) 
        {
            case "EatFood":

                break;
            case "Death":
                              
                break;
            case "foodGenerated":
                
                break;
        }
    }
}
