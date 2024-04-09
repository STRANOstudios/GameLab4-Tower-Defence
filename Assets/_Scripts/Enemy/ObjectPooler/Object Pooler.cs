using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    private List<GameObject> objects = new List<GameObject>();
    [SerializeField] int numberOfObjects=10;
    public static ObjectPooler instance;
    [SerializeField]GameObject[] enemy;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            for(int j=0;j<numberOfObjects; j++)
            {
                GameObject obj = Instantiate(enemy[i]);
                obj.SetActive(false);
                objects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(int x)
    {
        for(int i = 0;i < numberOfObjects; i++)
        {
            if (!objects[(x*10)+i].activeInHierarchy)
            {
                return objects[(x * 10) + i];
            }          
        }
        return null;
    }

}
