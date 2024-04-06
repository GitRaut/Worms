using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float boostedSpeed = 6f; // Double speed

    Vector3 direction;

    private void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        float currentSpeed = Input.GetKey(KeyCode.Space) ? boostedSpeed : speed; // Increase speed while holding down the left button

        transform.position = Vector2.MoveTowards(transform.position, direction, currentSpeed * Time.deltaTime);
    }
}
