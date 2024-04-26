using Unity.Netcode;
using UnityEngine;

public class Move : NetworkBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float boostedSpeed = 100f; // Double speed

    private Vector3 direction;
    private float curSpeed;
    private Camera mainCam;

    private bool isBoosted = false;//is bonus boosted
    private Vector3 mouseInput = Vector3.zero;

    public override void OnNetworkSpawn() => Init();

    private void Init()
    {
        curSpeed = speed;
        gameObject.name = Random.Range(0, 10).ToString();
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (!IsOwner || !Application.isFocused) return;

        if(isBoosted || Input.GetKey(KeyCode.Space)) curSpeed = boostedSpeed;
        else if (!isBoosted || Input.GetKeyUp(KeyCode.Space)) curSpeed = speed;

        mouseInput = Input.mousePosition;
        mouseInput.z = mainCam.nearClipPlane;
        direction = mainCam.ScreenToWorldPoint(mouseInput);
        transform.position = Vector2.MoveTowards(transform.position, direction, curSpeed * Time.deltaTime);
    }

    public void Boost() => isBoosted = true;

    public void ReBoost() => isBoosted = false;
}
