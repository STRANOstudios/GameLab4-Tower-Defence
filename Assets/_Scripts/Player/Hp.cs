using UnityEngine;

public class Hp : MonoBehaviour
{
    [SerializeField] private float hp = 100;

    public delegate void Death();
    public static event Death death;

    public delegate void Hit(float value);
    public static event Hit hit = null;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == 8)
        {
            hp -= other.transform.GetComponentInParent<Enemy>().Damage;
            hit?.Invoke(hp);

            if (hp <= 0) death?.Invoke();
        }
    }

    private void IncreaseHp(float value)
    {
        hp += value;
        hit?.Invoke(hp);
    }
}
