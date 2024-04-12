using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Shop Manager Settings")]
    [SerializeField, Min(0)] private float health;
    [SerializeField, Min(0)] private float damage;
    [SerializeField, Min(0)] private float speed;
    [Space]
    [SerializeField] private Canvas canvas;

    public delegate void SM(float value);
    public static event SM Health = null;
    public static event SM Damage = null;
    public static event SM Speed = null;

    public void HealthBtn()
    {
        Health?.Invoke(health);
        ReturnAtGame();
    }

    public void DamageBtn()
    {
        Damage?.Invoke(damage);
        ReturnAtGame();
    }

    public void SpeedBtn()
    {
        Speed?.Invoke(speed);
        ReturnAtGame();
    }

    private void ReturnAtGame()
    {
        Time.timeScale = 1.0f;
        canvas.gameObject.SetActive(false);
    }
}
