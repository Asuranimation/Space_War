using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "waveConfig",menuName = "ScriptableObject/Waypoint")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private Transform pathPrefab;
    
    [SerializeField] private float moveSpeed = 2f;
    
    [SerializeField] private List<GameObject> enemyPrefabs;

    [SerializeField] private List<GameObject> bossPrefabs;
    
    [SerializeField] private float MaxSpawnTime = 0.2f;
    
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }
    
    public GameObject GetEnemyPrefabs(int index)
    {
        return enemyPrefabs[index];
    }

    public GameObject GetBossPrefabs(int index)
    {
        return bossPrefabs[index];
    }
    
    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }
    
    public float GetMoveSpeed() => moveSpeed;
    
    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoint = new List<Transform>();
        for (int i = 0; i < pathPrefab.transform.childCount; i++)
        {
            Transform transformChild = pathPrefab.transform.GetChild(i);
            waypoint.Add(transformChild);
        }
        return waypoint;
    }
    
    public float GetRandomSpawn()
    {
        float spawnTime = Random.Range(0,MaxSpawnTime );
        
        return spawnTime;
    }
    
}
