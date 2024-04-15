using UnityEngine;

public class Boss : Enemy
{
    public delegate void EnemyDie(Enemy enemy);
    public event EnemyDie enemyDie = null;

    [SerializeField] new ParticleSystem gun2;
    float timer;

    public override void OnEnable()
    {
        base.OnEnable();
        timer=enemy.attackCooldown;
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        transform.LookAt(Vector3.zero);
        if (Vector3.Distance(transform.position, Vector3.zero) <= enemy.range)
        {
            rb.velocity = Vector3.zero;
            Attack();
        }
        else
        {
            Move();
            if(timer<=0)
            {
                gun2.transform.Rotate(new Vector3(Random.Range(-45,45),0f,0f));
                gun2.Play();
                timer = enemy.attackCooldown;

                if (audioSource && sound)
                {
                    audioSource.Stop();
                    audioSource.clip = sound;
                    audioSource.Play();
                }
            }
        }
        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
            enemyDie.Invoke(this);
        }
    }


}
