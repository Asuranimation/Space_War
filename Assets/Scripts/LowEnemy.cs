using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT INI BUDI TAMBAH
public class LowEnemy : Enemy
{
    List<Transform> waypoints = new List<Transform>();
    int index;
    private void Start()
    {
        index = 0;
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[index].transform.position;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        if (index < waypoints.Count)
        {
            while (Vector3.Distance(transform.position, waypoints[index].position) <= 0.5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[index].position, waveConfig.GetMoveSpeed());
                yield return null;
            }
        }
        else
        {
            yield break;
        }
        index++;
        StartCoroutine(Move());
    }
}
