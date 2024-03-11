using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    Vector3 direction;

    private void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        //transform.(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        //transform.Rotate(direction * rotationSpeed * Time.fixedDeltaTime);
    }
 
}
