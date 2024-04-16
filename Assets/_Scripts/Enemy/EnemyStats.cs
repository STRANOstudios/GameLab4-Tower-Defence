using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public WaveStats wave;
    public float speed;
    public float initialHp;
    public float initialDamage;
    public float hp;
    public float damage;
    public float range;
    public float dropChance;
    public float attackCooldown;
    public float inactiveGun;
    public float cowboyTeleport;
    public float stunTime;


    public void Increase()
    {
        hp += initialDamage / 100 * wave.hpIncrease;
        damage += initialDamage / 100 * wave.attackIncrease;
    }

}


