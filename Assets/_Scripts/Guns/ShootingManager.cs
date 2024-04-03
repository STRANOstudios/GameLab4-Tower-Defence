using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [Header("Particle System")]
    [SerializeField] List<PSManager> gun = new();

    private InputHandler inputHandler;
    private int index = 0;

    private void Start()
    {
        inputHandler = InputHandler.Instance;
    }

    private void Update()
    {
        Fire();
        Scroll();
    }

    private void Scroll()
    {
        if (inputHandler.ScrollInput > 0)
        {
            index = index - 1 < 0 ? gun.Count - 1 : index - 1;
        }
        else if(inputHandler.ScrollInput < 0)
        {
            index = index + 1 >= gun.Count ? 0 : index + 1;
        }
    }

    private void Fire()
    {
        if (inputHandler.FireInput)
        {
            gun[index].Shoot();

            Debug.Log("Fire");
        }
    }
}
