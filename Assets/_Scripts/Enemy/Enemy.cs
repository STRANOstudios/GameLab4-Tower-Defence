using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    protected Rigidbody rb;
    [SerializeField] protected EnemyStats enemy;

    public float Damage=> enemy.damage;
    protected float currentHp;
    protected float speedBackup;
    protected float nextTimeToShoot = 0;
    [SerializeField] new ParticleSystem particleSystem;

    public delegate void EnemyDie(Enemy enemy);
    public event EnemyDie enemyDie = null;

    [SerializeField] AudioClip sound;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        enemy.damage = enemy.initialDamage;
        enemy.hp = enemy.initialHp;
    }

    private void OnEnable()
    {
        currentHp = enemy.hp;
        speedBackup = enemy.speed;
    }

    public void Move()
    {
        rb.velocity =speedBackup * transform.forward;
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
        transform.LookAt(Vector3.zero);
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
            enemyDie.Invoke(this);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        currentHp -= other.GetComponent<PSManager>().GetDamage();
        if (other.tag == "Shocker")
        {
            StartCoroutine(Stun());
        }
    }


    IEnumerator Stun()
    {
        speedBackup = 0;
        yield return new WaitForSeconds(enemy.stunTime);
        speedBackup=enemy.speed;
    }

}
