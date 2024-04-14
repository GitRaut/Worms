using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float boostedSpeed = 6f; // Double speed

    private Vector3 direction;
    private float curSpeed;

    private bool isBoosted = false;//is bonus boosted

    private void Start() => curSpeed = speed;

    private void Update() => direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    private void FixedUpdate()
    {
        if(isBoosted || Input.GetKeyDown(KeyCode.Space)) curSpeed = boostedSpeed;
        else if (!isBoosted || Input.GetKeyUp(KeyCode.Space)) curSpeed = speed;

        transform.position = Vector2.MoveTowards(transform.position, direction, curSpeed * Time.deltaTime);
    }

    public void Boost() => isBoosted = true;

    public void ReBoost() => isBoosted = false;
}
