using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeTail : NetworkBehaviour
{
    [SerializeField] private Transform SnakeTailGfx;
    [SerializeField] private float circleDiameter;
    [SerializeField] private int startTail;

    private List<Transform> snakeTail = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();

    public NetworkVariable<ushort> length = new (1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server); //order for slith elements render
    private int order = 0;

    public override void OnNetworkSpawn()
    {
        length.Value = (ushort)startTail;
        if (!IsServer) length.OnValueChanged += LengthChanged;
    }

    private void Start()
    {
        positions.Add(SnakeTailGfx.position);
        for (int i = 0; i < length.Value; i++) AddTail();
    }

    private void Update()
    {
        float distance = ((Vector2)SnakeTailGfx.position - positions[0]).magnitude;

        if (distance > circleDiameter)
        {
            Vector2 direction = ((Vector2)SnakeTailGfx.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * circleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= circleDiameter;
        }

        for (int i = 0; i < snakeTail.Count; i++)
            snakeTail[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / circleDiameter);

    }

    public void AddLength()
    {
        length.Value += 1;
        AddTail();
    }

    private void LengthChanged(ushort previousValue, ushort newValue) => AddTail();

    private void AddTail()
    {
        Transform tail = Instantiate(SnakeTailGfx, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeTail.Add(tail);
        positions.Add(tail.position);

        order += 1;
        tail.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -order;
    }
}