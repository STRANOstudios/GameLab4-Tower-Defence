using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [Header("Particle System")]
    [SerializeField] List<PSManager> gun = new();

    List<ParticleCollisionEvent> collisionEvents = new();

    private InputHandler inputHandler;
    private int index = 0;

    private void Start()
    {
        inputHandler = InputHandler.Instance;
    }

    private void Update()
    {
        Fire();

        Debug.Log("Fire");
    }

    private void Fire()
    {
        if (inputHandler.FireInput)
        {
            gun[index].Shoot();
        }
    }
}
