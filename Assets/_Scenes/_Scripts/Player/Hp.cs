using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Hp : MonoBehaviour
{
    [SerializeField] protected float hp;
    void TakeDamage() { }
}
