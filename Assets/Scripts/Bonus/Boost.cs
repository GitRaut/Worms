using System.Collections;
using UnityEngine;

public class Boost : Bonus
{
    [Range(0f, 5f)] private float time;

    protected override void DoAction(GameObject obj)
    {
        if (!obj.TryGetComponent<Move>(out Move snake)) return;

        StartCoroutine(DoBoost(snake));
    }

    private IEnumerator DoBoost(Move snake)
    {
        snake.Boost();
        yield return new WaitForSeconds(time);
        snake.ReBoost();
    }
}
