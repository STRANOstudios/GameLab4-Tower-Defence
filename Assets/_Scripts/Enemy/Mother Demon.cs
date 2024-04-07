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
            GameObject child =ObjectPooler.instance.GetPooledObject();
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
