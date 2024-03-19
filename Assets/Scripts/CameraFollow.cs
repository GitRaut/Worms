using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void FixedUpdate()
    {
        if (!target) return;

        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
