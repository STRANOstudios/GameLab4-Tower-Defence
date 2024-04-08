using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpDemonPooler : ObjectPooler
{
    public static EmpDemonPooler instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
