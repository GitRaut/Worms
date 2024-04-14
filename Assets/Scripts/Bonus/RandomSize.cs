using UnityEngine;

public class RandomSize : Bonus
{
    [Range(0, 5)] 
    [SerializeField] private int maxValue;

    protected override void DoAction(GameObject obj)
    {
        if (!obj.TryGetComponent<SnakeGrow>(out SnakeGrow snake)) return;
        
        int addSize = Random.Range(0, maxValue);
        snake.Grow(addSize);
    }
}
