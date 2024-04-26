using Unity.Netcode;
using UnityEngine;

public class RandomSize : Bonus
{
    [Range(0f, 20f)]
    [SerializeField] private int maxValue;

    protected override void DoAction(GameObject obj)
    {
        if (!obj.TryGetComponent<SnakeGrow>(out SnakeGrow snake)) return;
        
        int addSize = Random.Range(0, maxValue);
        snake.Grow(addSize);
        gameObject.GetComponent<NetworkObject>().Despawn();
    }
}
