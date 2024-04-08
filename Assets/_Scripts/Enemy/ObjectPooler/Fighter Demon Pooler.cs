using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterDemonPooler : ObjectPooler
{
    public static FighterDemonPooler instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
