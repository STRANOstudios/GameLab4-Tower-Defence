using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : Hp
{


    public void TakeDamage(float damage)
    {
        hp-= damage;
        Debug.Log("Hit");
    }

    void OnCollisionEnter(Collision collision)
    {
        Enemy enemydmg=collision.gameObject.GetComponent<Enemy>();
        TakeDamage(enemydmg.GetDamage());
    }
}
