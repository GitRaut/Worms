using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeGrow : MonoBehaviour
{
     [SerializeField] private SnakeTail snakeTail;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            RemoveFood(other.gameObject);
            snakeTail.AddTail();
        }
    }

    private void RemoveFood(GameObject food)
    {
        FoodGenerator.instance.RemoveFood(food);
        Destroy(food, 0.02f);
    }
}
