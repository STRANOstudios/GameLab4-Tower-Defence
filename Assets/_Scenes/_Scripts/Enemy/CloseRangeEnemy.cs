using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRangeEnemy : Enemy
{
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        transform.LookAt(Vector3.zero);
    }
    public virtual void Move()
    {
        
        rb.velocity = transform.forward*speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //effetto dell close range enemy sul player
    }
    private void Update()
    {
        Move();
    }
}
