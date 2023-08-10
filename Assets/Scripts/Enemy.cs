using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT INI BUDI TAMBAH
public class Enemy : MonoBehaviour
{
    [SerializeField] protected ENEMYTYPE type;
    [SerializeField] protected int damageValue;
    [SerializeField] protected WaveConfig waveConfig;
}