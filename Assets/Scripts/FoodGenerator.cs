using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    [Header("Field")]
    [SerializeField] private float radius;
    [SerializeField] private int density;
    [SerializeField] private Color fieldColor;
    [SerializeField] private Transform foodContainer;

    [Header("Food")]
    [SerializeField] private List<GameObject> foodPrefabs;
    [SerializeField] private float breakTime;

    private List<SnakeGrow> players;
    private List<GameObject> createdFood = new List<GameObject>();

    public static FoodGenerator instance;

    private void Awake()
    {
        instance = this;
        StartCoroutine(GenerateFood());
    }

    private IEnumerator GenerateFood()
    {
        yield return new WaitForSeconds(breakTime);

        if(createdFood.Count < density)
        {
            Vector3 pos = Random.insideUnitCircle * radius;
            GameObject foodPref = foodPrefabs[Random.Range(0, foodPrefabs.Count)];
            GameObject food = Instantiate(foodPref, pos, Quaternion.identity, foodContainer);
            AddFood(food);
        }

        StartCoroutine(GenerateFood());
    }

    public void AddFood(GameObject food)
    {
        if(!createdFood.Contains(food)) createdFood.Add(food);  
    }

    public void RemoveFood(GameObject food)
    {
        if (createdFood.Contains(food)) createdFood.Remove(food);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = fieldColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
