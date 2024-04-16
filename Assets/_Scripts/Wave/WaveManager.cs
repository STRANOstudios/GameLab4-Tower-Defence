using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] int NumberOfWave = 1;
    [SerializeField] EnemyStats[] enemy;
    [SerializeField] WaveStats wave;
    [SerializeField] Transform[] portals;
    [SerializeField] float[] percentuals = new float[5];
    [SerializeField] Canvas canvas;
    [SerializeField]int arraylength=2;
    bool boss = true;

    public delegate void WM();
    public static event WM Shop = null;
    public delegate void WMIndex(int value);
    public static event WMIndex WaveIndex = null;

    private void Awake()
    {
        FindPercentual(arraylength);
    }

    public void FindPercentual(int x)
    {
        float total = 0;
        for (int i = 0; i < x; i++)
        {
            total += enemy[i].dropChance;
        }
        float percentual = 0;
        for (int i = 0; i < x; i++)
        {
            percentuals[i] = percentual + (enemy[i].dropChance * 100) / total;
            percentual += (enemy[i].dropChance * 100) / total;
        }
    }

    private void Start()
    {
        StartCoroutine(CreateWave(arraylength));
    }

    IEnumerator CreateWave(int x)
    {
        if (NumberOfWave == 8)
        {
            arraylength++;
        }else if (NumberOfWave == 16)
        {
            arraylength++;
        }
        yield return new WaitForSeconds(wave.timeBetweenWave);

        WaveIndex?.Invoke(NumberOfWave);

        for (int i = 0; i < wave.numberOfEnemy + (wave.enemyIncrease * NumberOfWave); i++)
        {
            yield return new WaitForSeconds(wave.enemyTime);      
            int perc = Random.Range(0, 100);
            float total = 0;
            Debug.Log(perc);
            if (NumberOfWave % 10 == 0&&boss)
            {
                boss = false;
                GameObject obj = ObjectPooler.instance.GetPooledObject(5);
                if (obj != null)
                {
                    obj.transform.position = portals[Random.Range(0, portals.Length)].position;
                    obj.SetActive(true);
                    obj.GetComponent<Enemy>().enemyDie += Check;
                }
                continue;
            }
            for (int j = 0; j < x; j++)
            {
                total = percentuals[j];
                if (perc < total)
                {
                    GameObject obj = ObjectPooler.instance.GetPooledObject(j);
                    if (obj != null)
                    {
                        obj.transform.position = portals[Random.Range(0, portals.Length)].position;
                        obj.SetActive(true);
                        obj.GetComponent<Enemy>().enemyDie += Check;
                    }
                    break;
                }
            }
        }
    }

    private void Check(Enemy enemy)
    {
        enemy.enemyDie -= Check;
        for (int i = 0; i < ObjectPooler.instance.objects.Count; i++)
        {
            if (ObjectPooler.instance.objects[i].activeInHierarchy)
            {
                return;
            }
        }
        NumberOfWave++;
        boss = true;
        for (int k = 0; k < arraylength; k++)
        {
            this.enemy[k].Increase();
        }

        OpenShop();

        StartCoroutine(CreateWave(arraylength));
    }

    private void OpenShop()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        canvas.gameObject.SetActive(true);
        Shop?.Invoke();
    }

}
