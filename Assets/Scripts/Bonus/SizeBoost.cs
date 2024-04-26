using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeBoost : Bonus
{
    [Range(0f, 5f)]
    [SerializeField] private float time;
    [SerializeField] private int boostSize;

    protected override void DoAction(GameObject obj)
    {
        if (!obj.TryGetComponent<SnakeGrow>(out SnakeGrow snake)) return;

        StartCoroutine(DoBoost(snake));
    }

    private IEnumerator DoBoost(SnakeGrow snake)
    {
        snake.Boost(boostSize);
        yield return new WaitForSeconds(time);
        snake.ReBoost(boostSize);
    }
}
