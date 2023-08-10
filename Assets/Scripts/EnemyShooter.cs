using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Enemy
{
    [SerializeField] private GameObject projectilePrefabs;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifeSpawn = 5f;
    [SerializeField] private float firingRate = 0.2f;
    [SerializeField] private bool useAI;
    
    [SerializeField] private GameObject projectilePrefab;
    
    [SerializeField] private float speedLaser;
    [SerializeField] private float rangeTimeToShoot;
    
    [SerializeField] private int poolSize = 20; 
    [SerializeField] private List<GameObject> projectilePool = new List<GameObject>();
    
    [SerializeField] private Transform tempObject;


    public bool isFiring;

    private Coroutine firingCoroutine;
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject laser = Instantiate(projectilePrefab,transform.position,Quaternion.identity);
            laser.SetActive(false);
            projectilePool.Add(laser);
        }
       
    }
    
    void Update()
    {
        StartCoroutine(FireContinuosly());
    }
    
    IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject laser = GetPooledObject();
            if (laser != null)
            {
                laser.GetComponent<Projectile>().damage = damageValue;//ini yg gw tambah
                laser.transform.position = transform.position;
                laser.SetActive(true);
                laser.GetComponent<Rigidbody2D>().velocity = Vector2.down * speedLaser;
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
