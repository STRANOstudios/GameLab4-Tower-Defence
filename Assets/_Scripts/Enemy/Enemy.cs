using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    Rigidbody rb;
    [SerializeField] protected EnemyStats enemy;

    protected float currentHp;
    float nextTimeToShoot = 0;
    [SerializeField] new ParticleSystem particleSystem;

    [SerializeField] AudioClip sound;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        currentHp = enemy.hp;
        transform.LookAt(Vector3.zero);
    }

    public void Move()
    {
        rb.velocity = transform.forward * enemy.speed;
    }

    public void Attack()
    {
        if (Time.time < nextTimeToShoot) return;
        particleSystem.Play();
        nextTimeToShoot = Time.time + enemy.attackCooldown;

        if (audioSource && sound)
        {
            audioSource.Stop();
            audioSource.clip = sound;
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) <= enemy.range)
        {
            rb.velocity = Vector3.zero;
            Attack();
        }
        else
        {
            Move();
        }
        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        currentHp -= other.GetComponent<PSManager>().GetDamage();
    }

    public float Damage => enemy.damage;
}
