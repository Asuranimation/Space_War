using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float speedLaser;
    [SerializeField] private float rangeTimeToShoot;
    [SerializeField] private int poolSize = 20; 
    [SerializeField] private List<GameObject> projectilePool = new List<GameObject>();
    [SerializeField] private Transform tempObject;
     
     void Start()
     {
         for (int i = 0; i < poolSize; i++)
         {
             GameObject laser = Instantiate(projectilePrefab,transform.position,quaternion.identity,tempObject);
             laser.SetActive(false);
             projectilePool.Add(laser);
         }
     }
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FireContinuosly());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopAllCoroutines();
        }
    }
    IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject laser = GetPooledObject();
            if (laser != null)
            {
                laser.transform.position = transform.position;
                laser.SetActive(true);
                laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * speedLaser;
                yield return new WaitForSeconds(rangeTimeToShoot);
            }
            else
            {
                yield break;
            }
        }
    }
    
    private GameObject GetPooledObject()
    {
        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                return projectilePool[i];
            }
        }
        return null;
    }
    
}
