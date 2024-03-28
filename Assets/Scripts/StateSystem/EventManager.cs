using System;
using UnityEngine;

public static class EventManager
{
    internal static Action<string> eventOnStateUpdate;

    internal static void CallOnGameStateUpdate(string our_event)
    {
        eventOnStateUpdate?.Invoke(our_event);
        Debug.Log(our_event);
    }

    internal static void ResetManager()
    {
        eventOnStateUpdate = null;
    }
}
