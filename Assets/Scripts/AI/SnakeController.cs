using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float speed = 5f;
    private Transform target;

    void Start()
    {
        target = null;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                Destroy(target.gameObject);
                target = null;
            }
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            target = other.transform;
        }
    }
}
