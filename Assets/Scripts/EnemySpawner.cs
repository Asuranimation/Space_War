using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    
    WaveConfig waveConfig;

    [SerializeField] private bool isLooping;

    [SerializeField] float timing;
    [SerializeField] int jumlahTurn;
    int turnLoop;
    [SerializeField] GameObject bossAviable;

    [SerializeField] Enemy[] listEnemy;

    void Start()
    {
        int random = Random.Range(0, listEnemy.Length);
        Instantiate(listEnemy[random]);
        StartCoroutine(SpawnEnemiesWave());
    }

    public WaveConfig GetCurrentwave()
    {
       return waveConfig;
    }

    IEnumerator SpawnEnemiesWave()
    {
        do
        {
            foreach (var wave in waveConfigs)
            {
                waveConfig = wave;
                for (int i = 0; i < waveConfig.GetEnemyCount(); i++)
                {
                    Instantiate(waveConfig.GetEnemyPrefabs(i),
                        waveConfig.GetStartingWayPoint().position,Quaternion.identity,
                        transform);
                    yield return new WaitForSeconds(timing); 
                }
            }
            yield return new WaitForSeconds(waveConfig.GetRandomSpawn());
            turnLoop++;
            if(turnLoop == jumlahTurn)
            {
                isLooping = false;
                bossAviable.SetActive(true);
            }
            
        } while (isLooping);
    }

  
}
