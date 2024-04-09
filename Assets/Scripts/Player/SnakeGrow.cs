using UnityEngine;

public class SnakeGrow : MonoBehaviour
{
     [SerializeField] private SnakeTail snakeTail; //snake tail component
     [SerializeField] private float scaleAmount; // additive scale to current scale of snake elements

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            Grow(other.gameObject);
        }
    }

    private void Grow(GameObject food)
    {
        snakeTail.AddTail();
        transform.localScale += Vector3.one * scaleAmount;

        EventManager.CallState("EatFood");
    }
}
