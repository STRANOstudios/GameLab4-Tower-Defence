using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    private List<GameObject> objects = new List<GameObject>();
    [SerializeField] int numberOfObjects=10;

    [SerializeField] GameObject enemy;

    private void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject obj=Instantiate(enemy);
            obj.SetActive(false);
            objects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0;i < numberOfObjects; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                return objects[i];
            }          
        }
        return null;
    }

}
