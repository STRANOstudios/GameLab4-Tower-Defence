using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherDemon : Enemy
{
    [SerializeField] int numberOfChild;

    private void OnDisable()
    {
        GameObject child = ObjectPooler.instance.GetPooledObject(5);
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


