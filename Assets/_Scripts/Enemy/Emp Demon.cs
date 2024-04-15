using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EmpDemon : Enemy
{
    public delegate void EnemyDelegate(float enemy);
    public static event EnemyDelegate enemyDelegate = null;

    [SerializeField] float lifetime;

    public  override void OnEnable()
    {
        base.OnEnable();
        lifetime =enemy.attackCooldown;
        StartCoroutine(Emp());
    }
    
    IEnumerator Emp()
    {
        yield return new WaitForSeconds(lifetime);
        enemyDelegate?.Invoke(enemy.inactiveGun);
        gameObject.SetActive(false);
    }
}
