using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall"))
        {
            gameObject.SetActive(false);
        }
        else if(other.CompareTag("Enemies"))
        {
            var hit = other.GetComponent<Health>();
            hit.TakeDamage(20);
            gameObject.SetActive(false);
        }
    }
}
