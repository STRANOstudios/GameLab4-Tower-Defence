using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]int NumberOfWave=0;
    [SerializeField]EnemyStats[] enemy;
    [SerializeField]WaveStats[] wave;
    [SerializeField]float[] percentuals=new float[5];
    [SerializeField] ObjectPooler pooler;

    private void Awake()
    {
        FindPercentual(4);
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
        for (int i = 0; i < wave[NumberOfWave].NumberOfEnemy; i++)
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
                            obj.GetComponent<Enemy>().enemyDie+= Check;
                            break;

                        }
                }
                else
                {
                    total += percentuals[j];
                }
            }
        }
    }


    
    private void Start()
    {
        CreateWave(4);
    }

    private void Check(Enemy enemy)
    {
       enemy.enemyDie -= Check;
       for (int i = 0;i<pooler.objects.Count;i++)
        {
            if (pooler.objects[i].activeInHierarchy)
            {
                return;
            }
       }
        NumberOfWave++;
       CreateWave(3);
    }

}
