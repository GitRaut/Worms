using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform Snake;
    public Transform[] Food;

    private bool isAIActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isAIActive = !isAIActive; // Switching AI
        }

        if (!isAIActive || Food.Length == 0)
        {
            return;
        }

        Transform closestFood = GetClosestFood();
        MoveTowards(closestFood);
    }

    Transform GetClosestFood()
    {
        Transform closestFood = Food[0];
        float closestDistance = Vector3.Distance(Snake.position, Food[0].position);

        foreach (Transform food in Food)
        {
            float distance = Vector3.Distance(Snake.position, food.position);
            if (distance < closestDistance)
            {
                closestFood = food;
                closestDistance = distance;
            }
        }

        return closestFood;
    }

    void MoveTowards(Transform target)
    {
        Vector3 direction = target.position - Snake.position;
        Snake.Translate(direction.normalized * Time.deltaTime);
    }
}
