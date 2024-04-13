using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    [Header("Field")]
    [SerializeField] private float radius; //radius of generate zone
    [SerializeField] private int density; //max count of food in generate zone
    [SerializeField] private Color fieldColor; //color if gizmos circle
    [SerializeField] private Transform foodContainer; //transform with all food

    [Header("Food")]
    [SerializeField] private List<GameObject> foodPrefabs; 
    [SerializeField] private float breakTime; //time between generations

    private List<GameObject> createdFood = new List<GameObject>(); //list with all generated food

    private void Start() => StartCoroutine(GenerateFood());

    private IEnumerator GenerateFood()
    {
        yield return new WaitForSeconds(breakTime);

        if(createdFood.Count < density)
        {
            Vector3 pos = Random.insideUnitCircle * radius;
            GameObject foodPref = foodPrefabs[Random.Range(0, foodPrefabs.Count)];
            GameObject food = Instantiate(foodPref, pos, Quaternion.identity, foodContainer);
            EventManager.CallState("foodGenerated");
        }

        StartCoroutine(GenerateFood());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = fieldColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
