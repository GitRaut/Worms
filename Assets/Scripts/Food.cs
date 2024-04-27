using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Food : NetworkBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Snake")) return;

        if (!NetworkManager.Singleton.IsServer) return;

        if (other.gameObject.TryGetComponent(out SnakeGrow snakeGrow)) snakeGrow.Grow();

        NetworkObject.Despawn(true);
    }
}
