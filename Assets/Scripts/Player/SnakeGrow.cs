using UnityEngine;

public class SnakeGrow : MonoBehaviour
{
     [SerializeField] private SnakeTail snakeTail; //snake tail component
     [SerializeField] private float scaleAmount; // additive scale to current scale of snake elements

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other, 0.02f);
            Grow(other.gameObject);
        }
    }

    private void Grow(GameObject food)
    {
        snakeTail.AddTail();
        transform.localScale += Vector3.one * scaleAmount;

        EventManager.CallOnGameStateUpdate("EatFood");
    }
}
