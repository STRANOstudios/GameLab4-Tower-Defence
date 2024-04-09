using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherDemon : Enemy
{
    [SerializeField] int numberOfChild;

    private void Update()
    {

        if (Vector3.Distance(transform.position, Vector3.zero) <= enemy.range)
        {
            rb.velocity = Vector3.zero;
            Attack();
        }
        else
        {
            Move();
        }
        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
        }


        if (currentHp<=0)
        {
            GameObject child =ChildDemonpooler.instance.GetPooledObject(4);
            gameObject.SetActive(false);
            for (int i = 0; i < numberOfChild; i++)
            {
                if (child != null)
                {
                    child.transform.position = transform.position;
                    child.SetActive(true);
                }
            }
        }
    }
}
