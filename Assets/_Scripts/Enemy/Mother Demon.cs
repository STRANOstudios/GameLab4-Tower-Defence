using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherDemon : Enemy
{
    [SerializeField] int numberOfChild;


    private void OnDisable()
    {
        for (int i = 0; i < numberOfChild; i++)
        {
            GameObject child = ObjectPooler.instance.GetPooledObject(4);
            if (child != null)
            {
                child.transform.position = new Vector3(transform.position.x+numberOfChild*2, transform.position.y, transform.position.z);
                child.SetActive(true);
            }
        }
    }
}


