using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float speed = 1.0f;
    private bool isSpeedingUp = false;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isSpeedingUp = true;
        }
        else
        {
            isSpeedingUp = false;
        }

        Move();
    }

    void Move()
    {
        if (isSpeedingUp)
        {
            transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
