using UnityEngine;

public class PSManager : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField, Min(0)] float damage = 0f;
    [SerializeField, Min(0)] float fireRatio = 0.5f;
    [SerializeField, Min(0)] int magazine = 0;
    [SerializeField, Tooltip("if is checked, the magazine will be infinite")] bool infiniteMagazine = false;

    [Header("Audio Source")]
    [SerializeField] AudioClip sound;

    private new ParticleSystem particleSystem;
    private float nextTimeToShoot = 0f;
    private AudioSource audioSource;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        ShopManager.Damage += IncreaseDamageByPercentage;
        ShopManager.Speed += DecreaseFireRatio;
    }

    private void OnDisable()
    {
        ShopManager.Damage -= IncreaseDamageByPercentage;
        ShopManager.Speed -= DecreaseFireRatio;
    }

    public float GetDamage()
    {
        return this.damage;
    }

    public void Shoot()
    {
        if (Time.time < nextTimeToShoot || !(magazine > 0 || infiniteMagazine)) return;

        particleSystem.Play();
        nextTimeToShoot = Time.time + fireRatio;
        magazine--;

        PlayAudio();
    }

    private void IncreaseDamageByPercentage(float percentage)
    {
        damage *= (percentage / 100f);
    }

    private void DecreaseFireRatio(float percentage)
    {
        fireRatio *= (percentage / 100f);
    }

    protected void PlayAudio()
    {
        if (audioSource && sound)
        {
            audioSource.Stop();
            audioSource.clip = sound;
            audioSource.Play();
        }
    }

    public float Damage => damage;

    public int Magazine { get { return magazine; /*reload UI method*/ } set { magazine = value; /*reload UI method*/ } }
}
