using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : Hp
{


    public void TakeDamage(float damage)
    {
        hp -= damage;
        Debug.Log(hp);
    }


    private void OnParticleCollision(GameObject other)
    {
        //Enemy enemy=other
        //quando il nemico spara prendi danno
    }
}
