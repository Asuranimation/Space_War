using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health ;
    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        DamageDealer damageDealer = collider2d.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    
    
    

}
