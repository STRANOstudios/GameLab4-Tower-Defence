using UnityEngine;

public class Hp : MonoBehaviour
{
    [SerializeField] private float hp = 100;

    public delegate void Death();
    public static event Death death;

    private void OnParticleCollision(GameObject other)
    {
        if(other.layer == 8)
        {
            hp -= other.GetComponent<Enemy>().Damage;
            if(hp <= 0) death?.Invoke();
        }
    }
}
