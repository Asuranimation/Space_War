using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject bossPrefabs;
    private void OnEnable()
    {
        Instantiate(bossPrefabs, transform.position, Quaternion.identity);
    }
}
