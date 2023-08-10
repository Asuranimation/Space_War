using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    public WaveConfig waveConfig;
    public List<Transform> waypoints;
    private int wayPointIndex = 0;


    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentwave();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[wayPointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }
    
    public virtual void FollowPath()
    {
        if (wayPointIndex < waypoints.Count) 
        {
            Vector2 targetPosition = waypoints[wayPointIndex].position;
            float moveSpeed = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
            if ((Vector2)transform.position == (Vector2) targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
