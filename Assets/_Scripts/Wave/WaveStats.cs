using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaveStats : ScriptableObject
{
    public int numberOfEnemy;
    public float timeBetweenWave;
    public float enemyTime;

    [Header("The values are in percentual from 0 to 100")]
    [Range(0, 100)] public float speedIncrease;
    [Range(0, 100)] public float attackIncrease;
    [Range(0, 100)] public float hpIncrease;
    [Min (0)] public float enemyIncrease;

}
