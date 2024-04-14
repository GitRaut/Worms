using UnityEngine;

public enum BonusType
{
    RandomSize,
    Boost,
    Magnet,
    SizeBoost,
    Zoom
}

public class Bonus : MonoBehaviour
{
    [SerializeField] protected BonusType type;

    public BonusType bonusType 
    { 
        get { return type; } 
        private set { type = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision) => DoAction(collision.gameObject);

    protected virtual void DoAction(GameObject obj) { }
}
