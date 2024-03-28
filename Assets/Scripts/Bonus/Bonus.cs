using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private int influence; //in procentage
    [SerializeField] private float existTime; //existing time

    private void OnTriggerEnter2D(Collider2D collision) => DoAction();

    protected virtual void DoAction() { }
}
