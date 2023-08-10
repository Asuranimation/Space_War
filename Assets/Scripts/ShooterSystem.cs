using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShooterSystem : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileLifetime;
    [SerializeField] private float firingRate;
    [SerializeField] GameObject bulletRight,bulletLeft;

    [SerializeField] bool isBoss;


    public bool isFiring;

    private Coroutine firingCoroutine;


    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            if(isBoss)
            {
                GameObject laserL = Instantiate(projectilePrefab, bulletRight.transform.position, quaternion.identity);
                GameObject laserR = Instantiate(projectilePrefab, bulletLeft.transform.position, quaternion.identity);

                Rigidbody2D rb_L = laserL.GetComponent<Rigidbody2D>();
                Rigidbody2D rb_R = laserR.GetComponent<Rigidbody2D>();
                if (rb_L & rb_R != null)
                {
                    rb_L.velocity = Vector2.down * projectileSpeed;
                    rb_R.velocity = Vector2.down * projectileSpeed;
                }
                yield return new WaitForSeconds(firingRate);
            }
            else
            {
                GameObject laser = Instantiate(projectilePrefab, transform.position, quaternion.identity);
                Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    rb.velocity = Vector2.down * projectileSpeed;
                }
                yield return new WaitForSeconds(firingRate);
            }
        }
    }
}
