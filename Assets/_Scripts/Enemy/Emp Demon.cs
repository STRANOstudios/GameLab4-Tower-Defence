using UnityEngine;

public class EmpDemon : Enemy
{
    public delegate void EnemyDelegate(float enemy);
    public static event EnemyDelegate enemyDelegate = null;

    public delegate void EnemyDie(Enemy enemy);
    public event EnemyDie EmpDie = null;

    [SerializeField] float lifetime;

    private void Awake()
    {
        lifetime = enemy.attackCooldown;
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
            EmpDie.Invoke(this);
        }
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            enemyDelegate?.Invoke(enemy.inactiveGun);
            gameObject.SetActive(false);
        }
    }
}
