using UnityEngine;

public class PSManager : MonoBehaviour
{
    [Header("Gun Settings")]
    [SerializeField, Min(0)] float damage = 0f;
    [SerializeField, Min(0)] float cooldownWindow = 0.5f;
    [SerializeField, Min(0)] int magazine = 0;

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

    public float  GetDamage()
    {
        return this.damage;
    }

    public void Shoot()
    {
        if (Time.time < nextTimeToShoot) return;
        particleSystem.Play();
        nextTimeToShoot = Time.time + cooldownWindow;

        if (audioSource && sound)
        {
            audioSource.Stop();
            audioSource.clip = sound;
            audioSource.Play();
        }
    }
}
