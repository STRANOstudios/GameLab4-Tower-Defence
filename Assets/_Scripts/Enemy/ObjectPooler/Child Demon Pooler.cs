using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDemonpooler : ObjectPooler
{
    public static ChildDemonpooler instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
