using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Snake"))
        {
            other.gameObject.GetComponent<SnakeGrow>().Grow();
            gameObject.GetComponent<NetworkObject>().Despawn();
        }
    }
}
