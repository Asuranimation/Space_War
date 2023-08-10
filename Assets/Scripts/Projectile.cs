using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;//ini gw tambah
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall"))
        {
            gameObject.SetActive(false);
        }
        else if(other.CompareTag("Enemies"))
        {
            var hit = other.GetComponent<Health>();
            hit.TakeDamage(damage);//ini gw ubah
            gameObject.SetActive(false);
        }
    }
}
