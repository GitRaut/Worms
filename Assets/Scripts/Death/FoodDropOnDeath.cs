using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class FoodDropOnDeath : MonoBehaviour
{
  public GameObject Food;
  
    private void OnDestroy()
    {
        if (!NetworkManager.Singleton.IsServer) return;

        GameObject food = Instantiate(Food, transform.position, Quaternion.identity);
        var foodNetwork = food.GetComponent<NetworkObject>();
        foodNetwork.Spawn(true);
    }
}
