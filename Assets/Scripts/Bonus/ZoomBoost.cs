using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomBoost : Bonus
{
    [Range(0f, 5f)] private float time;
    [SerializeField] private int boostSize;

    protected override void DoAction(GameObject obj) => DoBoost();

    private IEnumerator DoBoost()
    {
        for (int i = 0; i < boostSize; i++) { EventManager.CallState("CameraZoom"); }
        yield return new WaitForSeconds(time);
        for (int i = 0; i < boostSize; i++) { EventManager.CallState("CameraReZoom"); }
    }
}
