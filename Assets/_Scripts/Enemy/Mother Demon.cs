using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherDemon : Enemy
{
    [SerializeField] int numberOfChild;

    private void Update()
    {
        if (currentHp<=0)
        {
            gameObject.SetActive(false);
            //attiva figli 

        }
    }
}
