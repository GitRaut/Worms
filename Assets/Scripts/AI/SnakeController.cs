using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Transform target = null;
    private Vector3 direction = Vector3.right;

    void Update()
    {
        if (target && Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            Destroy(target.gameObject);
            target = null;
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            target = other.transform;
            direction = target.position - transform.position;
        }
    }
}
