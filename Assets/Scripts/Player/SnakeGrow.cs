using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(SnakeTail))]
[RequireComponent(typeof(Move))]
public class SnakeGrow : MonoBehaviour
{
    [SerializeField] private float scaleAmount; // additive scale to current scale of snake elements

    public SnakeTail snakeTail { get; private set; } //snake tail component
    public Move moveScript { get; private set; } //snake move component

    public bool isBoosted = false; //bonus size boost
    private int curBoost;

    private void Start()
    {
        snakeTail = GetComponent<SnakeTail>();
        moveScript = GetComponent<Move>();
    }

    public void Grow(int sizeBoost = 1)
    {
        if (!isBoosted) curBoost = sizeBoost;

        for (int i = 0; i < curBoost; i++)
        {
            snakeTail.AddLength();
            transform.localScale += Vector3.one * scaleAmount;

            if (transform.CompareTag("Snake"))
                EventManager.CallState("CameraZoom");
        }
    }

    public void Boost(int boost)
    {
        isBoosted = true;
        curBoost = boost;
    }

    public void ReBoost(int boost)
    {
        isBoosted = false;
        curBoost = 1;
    }
}
