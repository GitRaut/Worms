using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSingleton : MonoBehaviour
{
    public static MainSingleton instance;

    public FoodGenerator FoodGenerator { get; private set; }

    private void Awake()
    {
        instance = this;

        FoodGenerator = GetComponent<FoodGenerator>();
    }
}
