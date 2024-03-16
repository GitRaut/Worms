using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDropOnDeath : MonoBehaviour
{
  public GameObject Food;
  
  private void OnDestroy()
  {
     Instantiate(Food, transform.position, Quaternion.identity);
  }
}
