using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterDemon : MonoBehaviour, IEnemy
{
    Rigidbody rb;
    [SerializeField] Enemy enemy;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        transform.LookAt(Vector3.zero);
    }
    public void Move()
    {       
        rb.velocity = transform.forward * enemy.speed;
    }
    public  void Attack()
    {
        //il nemico spara e fa danno come?

    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero)<=enemy.range)
        {
            Attack();
        }else
        {
            Move();
        }
    }
}
