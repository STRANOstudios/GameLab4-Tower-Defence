using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyDemon : Enemy
{



    public delegate void EnemyDie(Enemy enemy);
    public event EnemyDie enemyDie = null;



    //IEnumerator Teleport()
    //{
    //    Attack();
    //    yield return new WaitForSeconds(enemy.attackCooldown+0.5f);
    //    transform.Translate(new Vector3(Mathf.Sin(Random.Range(-1f, 1f)), 0, 0)*10);

    //}
    private void Update()
    {
        transform.LookAt(Vector3.zero);
        if (Vector3.Distance(transform.position, Vector3.zero) <= enemy.range)
        {
            Attack();
            transform.Translate(new Vector3(Mathf.Sin(Random.Range(-1f, 1f)), 0, 0) * enemy.cowboyTeleport);
        }
        else
        {
            Move();
        }
        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
            enemyDie.Invoke(this);
        }
    }


}