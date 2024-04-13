using UnityEngine;

public class DeathOnWallCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Snake"))
        {
            Destroy(other.gameObject);
            Debug.Log("Игрок умер от столкновения со стеной");
        }
    }
}
