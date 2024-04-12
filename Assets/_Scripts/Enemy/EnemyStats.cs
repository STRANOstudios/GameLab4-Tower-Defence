using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public WaveStats wave;
    public float speed;
    public float hp;
    public float damage;
    public float range;
    public float coinDrop;
    public float dropChance;
    public float attackCooldown;
    public float inactiveGun;
    public float cowboyTeleport;
    public float stunTime;

    public void Increase()
    {
        hp += hp / 100 *wave.hpIncrease;
        damage += damage / 100 * wave.attackIncrease;
        speed += speed / 100 * wave.speedIncrease;
    }

}


