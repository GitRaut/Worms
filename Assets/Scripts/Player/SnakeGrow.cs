using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeGrow : MonoBehaviour
{
     [SerializeField] private SnakeTail snakeTail;
     public float scaleAmount = 0.1f; // Количество, на которое увеличивается объект при соприкосновении с едой

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            RemoveFood(other.gameObject);
            snakeTail.AddTail();

            transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);
            Debug.Log("Объект увеличился");
        }

    }
    private void RemoveFood(GameObject food)
    {
        FoodGenerator.instance.RemoveFood(food);
        Destroy(food, 0.02f);
    }
}
