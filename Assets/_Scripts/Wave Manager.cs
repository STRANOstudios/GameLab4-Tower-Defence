using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]int NumberOfWave=0;
    [SerializeField]EnemyStats[] enemy;
    [SerializeField]float[] percentuals=new float[5];
    [SerializeField]int enemytospawnNumber;
    [SerializeField] ObjectPooler pooler;

    private void Awake()
    {
        FindPercentual(3);
    }

    public void FindPercentual(int x)
    {
        float total = 0;
        for(int i=0; i<x; i++)
        {
            total += enemy[i].dropChance;
        }
        for(int i = 0; i < x; i++) {
            percentuals[i] = (enemy[i].dropChance * 100) / total;
        }  
    }


    void CreateWave(int x)
    {
        for (int i = 0; i < 20; i++)
        {
            Debug.Log(i);
            int perc = Random.Range(0, 101);
            float total = 0;
            for (int j = 0; j < x; j++)
            {
                Debug.Log(perc);
                if (perc >= total && perc < percentuals[j]+total)
                {
                    GameObject obj =pooler.GetPooledObject(j);
                        if (obj != null)
                        {
                            obj.transform.position = Vector3.forward * 20;
                            obj.SetActive(true);
                        }
                }
                else
                {
                    total += percentuals[j];
                }
            }
        }
    }

    void Update()
    {      
        if (NumberOfWave<25)
        {
            switch (NumberOfWave)
            {
                case int n when (n<5):
                    CreateWave(3);
                    NumberOfWave++;
                    break;
                case int n when(n<10):
                    NumberOfWave++;
                    break;
                case int n when (n<15):
                    //FindPercentual(5);
                    NumberOfWave++;
                    break;
                case int n when (n<29):
                    NumberOfWave++;
                    break;
                case int n when (n<25):
                    NumberOfWave++;
                    break;
                default:
                    break;
            }
        }
        
    }
}
