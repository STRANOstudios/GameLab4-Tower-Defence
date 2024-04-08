using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]int NumberOfWave=0;
    [SerializeField]float wave;

    void Start()
    {
        //NumberOfWave = 0;
    }

    void Update()
    {

        if (NumberOfWave<25)
        {
            switch (wave)
            {
                case 0:
                    //NumberOfWave++;
                    Debug.Log(wave+NumberOfWave + "0");
                    break;
                case 1:
                    //NumberOfWave++;
                    Debug.Log(wave+NumberOfWave + "1");
                    break;
                case 2:
                    //NumberOfWave++;
                    Debug.Log(wave + NumberOfWave + "2");
                    break;
                case 3:
                    //NumberOfWave++;
                    Debug.Log(wave+NumberOfWave + "3");
                    break;
                case 4:
                    //NumberOfWave++;
                    wave++;
                    Debug.Log(wave + NumberOfWave + "4");
                    break;
                default:
                    break;
            }
        }
        
    }
}
