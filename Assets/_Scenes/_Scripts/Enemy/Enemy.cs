using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy  : Hp
{
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;


    public float GetDamage()
    {
        return this.damage;
    }
    public void TakeDamage(float damage)
    {
        hp=hp-damage;
        if(hp <= 0)
        {
            this.gameObject.SetActive(false);
        }

    }

    protected void Move()
    {

    }


    private void OnParticleCollision(GameObject other)
    {
        PSManager gundmg=other.gameObject.GetComponent<PSManager>();
        TakeDamage(gundmg.GetDamage());
    }
}
