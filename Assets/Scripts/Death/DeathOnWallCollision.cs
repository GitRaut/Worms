using Unity.Netcode;
using UnityEngine;

public class DeathOnWallCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Snake"))
        {
            other.gameObject.GetComponent<NetworkObject>().Despawn();
            Debug.Log("Игрок умер от столкновения");
        }
    }
}
