using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAI : MonoBehaviour
{
    public float movementSpeed = 5f;

    private GameObject[] foodTags;
    private Transform targetFood;
    private int currentFoodIndex = 0;

    void Start()
    {
        foodTags = GameObject.FindGameObjectsWithTag("Food");
        FindClosestFood();
    }

    void Update()
    {
        if (targetFood == null)
        {
            FindClosestFood();
        }
        else
        {
            Vector3 direction = targetFood.position - transform.position;
            transform.Translate(direction.normalized * movementSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetFood.position) < 0.1f)
            {
                Destroy(targetFood.gameObject);
                currentFoodIndex++;
                if (currentFoodIndex < foodTags.Length)
                {
                    FindClosestFood();
                }
                else
                {
                    targetFood = null;
                }
            }
        }
    }

    void FindClosestFood()
    {
        float minDistance = Mathf.Infinity;
        foreach (GameObject foodTag in foodTags)
        {
            float distance = Vector3.Distance(transform.position, foodTag.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                targetFood = foodTag.transform;
            }
        }
    }
}
