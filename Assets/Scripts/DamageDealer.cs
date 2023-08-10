using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    public int GetDamage()
    {
        return damage;
    }

    public void hit()
    {
        Destroy(gameObject);
    }

}
