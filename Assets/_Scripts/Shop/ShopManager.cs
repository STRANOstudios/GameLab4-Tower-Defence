using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Shop Manager Settings")]
    [SerializeField, Min(0)] private float health;
    [SerializeField, Min(0)] private float damage;
    [SerializeField, Min(0)] private float speed;

    public delegate void SM(float value);
    public static event SM Health = null;
    public static event SM Damage = null;
    public static event SM Speed = null;

    public void HealthBtn()
    {
        Health?.Invoke(health);
    }

    public void DamageBtn()
    {
        Damage?.Invoke(damage);
    }

    public void SpeedBtn()
    {
        Speed?.Invoke(speed);
    }
}
