using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
        PlayerData.instance.FoodGenerator.RemoveFood(food);
        Destroy(food, 0.02f);
    }
}
