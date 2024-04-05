using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpDemon : Enemy
{
    private delegate void EnemyDelegate(float enemy);
    private static event EnemyDelegate enemyDelegate = null;

    float lifetime;
    private void Awake()
    {
        lifetime = enemy.attackCooldown;
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            enemyDelegate?.Invoke(enemy.inactiveGun);
            gameObject.SetActive(false);
        }
    }


}
