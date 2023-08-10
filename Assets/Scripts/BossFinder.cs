using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinder : MonoBehaviour
{
    [SerializeField] Transform BossPath;
     List<Transform> bossWayPoint;
    private int wayPointIndex = 0;
    float moveSpeed;


    void Start()
    {
        bossWayPoint = GetWayBoss();
        transform.position = bossWayPoint[wayPointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    public List<Transform> GetWayBoss()
    {
        List<Transform> waypoint = new List<Transform>();
        for (int i = 0; i < BossPath.transform.childCount; i++)
        {
            Transform transformChild = BossPath.transform.GetChild(i);
            waypoint.Add(transformChild);
        }
        return waypoint;
    }

    public  void FollowPath()
    {
        if (wayPointIndex < bossWayPoint.Count)
        {
            Vector2 targetPosition = bossWayPoint[wayPointIndex].position;
            float moveSpeed = 2f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
            if ((Vector2)transform.position == (Vector2)targetPosition)
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
