using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpDemon : Enemy
{
    private delegate void EnemyDelegate(float enemy);
    private event EnemyDelegate enemyDelegate;

    float lifetime;
    private void Awake()
    {
        lifetime = enemy.attackCooldown;
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            gameObject.SetActive(false);
            enemyDelegate(enemy.inactiveGun);
        }
    }


}
