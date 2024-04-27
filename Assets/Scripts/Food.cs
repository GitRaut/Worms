using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Food : NetworkBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(1);
        if (!other.gameObject.CompareTag("Snake")) return;
        Debug.Log(2);
        if (!NetworkManager.Singleton.IsServer) return;
        Debug.Log(3);
        if (other.gameObject.TryGetComponent(out SnakeGrow snakeGrow)) snakeGrow.Grow();
        Debug.Log(4);
        NetworkObject.Despawn(true);
    }
}
