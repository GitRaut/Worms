using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ZoomBoost : Bonus
{
    [Range(0f, 20f)]
    [SerializeField] private float time;
    [SerializeField] private int boostSize;

    protected override void DoAction(GameObject obj)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(DoBoost());
    }

    private IEnumerator DoBoost()
    {
        for (int i = 0; i < boostSize; i++) { EventManager.CallState("CameraZoom"); }
        yield return new WaitForSeconds(time);
        for (int i = 0; i < boostSize; i++) { EventManager.CallState("CameraReZoom"); }
        gameObject.GetComponent<NetworkObject>().Despawn();
    }
}
