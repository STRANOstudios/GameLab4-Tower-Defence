using UnityEngine;

public class EmpDemon : Enemy
{
    public delegate void EnemyDelegate(float enemy);
    public static event EnemyDelegate enemyDelegate = null;

    [SerializeField] float lifetime;

    private void Awake()
    {
        lifetime = enemy.attackCooldown;
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            enemyDelegate?.Invoke(enemy.inactiveGun);
            gameObject.SetActive(false);
        }
    }
}
