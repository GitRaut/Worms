using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    private Vector3 TPosition;
    private bool isMoving = false;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            TriggerPosition();
        }

        if(isMoving)
        {
            ItsMove();
        }
    }

    void TriggerPosition()
    {
        TPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TPosition.z = transform.position.z;

        isMoving = true;
    }

    void ItsMove()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, TPosition);
        transform.position = Vector3.MoveTowards(transform.position, TPosition, speed * Time.deltaTime);

        if(transform.position == TPosition)
        {
            isMoving = false;
        }
    }
}
