using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;

    public FoodGenerator FoodGenerator { get; private set; }

    private void Awake()
    {
        instance = this; 

        FoodGenerator = GetComponent<FoodGenerator>();
    }
}
