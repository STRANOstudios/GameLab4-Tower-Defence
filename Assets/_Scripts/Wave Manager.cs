using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]int NumberOfWave=0;
    [SerializeField]EnemyStats[] enemy;
    [SerializeField]float[] percentuals=new float[5];
    [SerializeField]int enemytospawnNumber;
    [SerializeField] ObjectPooler[] pooler;

    private void Awake()
    {
        FindPercentual(2);
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
            float perc = Random.Range(0f, 100f);
            float total = 0;
            for (int j = 0; j < x; j++)
            {
                if (perc >= total || perc < percentuals[j]+total)
                {
                    GameObject obj =pooler[j].GetPooledObject();
                        if (obj != null)
                        {
                            obj.transform.position = Vector3.forward * 20;
                            obj.SetActive(true);
                        }
                }
                return;
                total += percentuals[j];
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
                    CreateWave(2);
                    NumberOfWave++;
                    break;
                case int n when(n<10):
                    NumberOfWave++;
                    break;
                case int n when (n<15):
                    FindPercentual(4);
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
