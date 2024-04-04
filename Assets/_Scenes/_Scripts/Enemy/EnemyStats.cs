using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public float speed;
    public float hp;
    public float damage;
    public float range;
    public float coinDrop;
    public float dropChance;
    public float attackCooldown;

}


