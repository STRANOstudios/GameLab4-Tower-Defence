using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]int NumberOfWave=0;
    [SerializeField]EnemyStats[] enemy;
    [SerializeField]WaveStats[] wave;
    [SerializeField]float[] percentuals=new float[5];

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
        float percentual=0;
        for(int i = 0; i < x; i++) {
            percentuals[i] = percentual+(enemy[i].dropChance * 100) / total;
            percentual += (enemy[i].dropChance * 100) / total;
        }  
    }
    private void Start()
    {
        CreateWave(4);
    }

    void CreateWave(int x)
    {
        for (int i = 0; i < wave[NumberOfWave].NumberOfEnemy; i++)
        {
            int perc = Random.Range(0, 101);
            float total = 0;
            Debug.Log(perc);
            for (int j = 0; j < x; j++)
            {
                
                if (perc < total + percentuals[j])
                {
                    GameObject obj = ObjectPooler.instance.GetPooledObject(j);
                    if (obj != null)
                    {
                        obj.transform.position = Vector3.forward * 20;
                        obj.SetActive(true);
                        obj.GetComponent<Enemy>().enemyDie += Check;
                    }
                    break;
                }
                total += percentuals[j];
            }
        }
    }
    private void Check(Enemy enemy)
    {
       enemy.enemyDie -= Check;
       for (int i = 0;i<ObjectPooler.instance.objects.Count;i++)
        {
            if (ObjectPooler.instance.objects[i].activeInHierarchy)
            {
                return;
            }
       }
        NumberOfWave++;
       CreateWave(4);
    }

}
