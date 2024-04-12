using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [Header("Particle System")]
    [SerializeField] List<PSManager> gun = new();

    private InputHandler inputHandler;
    private int index = 0;
    private float unlockTime = 0;
    private float buttonHoldStartTime;

    public delegate void Change(int value);
    public static event Change indexGun = null;

    private void Start()
    {
        inputHandler = InputHandler.Instance;
    }

    private void Update()
    {
        Fire();
        Scroll();
    }

    private void OnEnable()
    {
        EmpDemon.enemyDelegate += LockWeapon;
    }
    private void OnDisable()
    {
        EmpDemon.enemyDelegate -= LockWeapon;
    }

    private void Scroll()
    {
        if (gun.Count < 1) return;

        if (inputHandler.ScrollInput.y > 0)
        {
            index = index - 1 < 0 ? gun.Count - 1 : index - 1;
        }
        else if (inputHandler.ScrollInput.y < 0)
        {
            index = index + 1 >= gun.Count ? 0 : index + 1;
        }

        indexGun?.Invoke(index);
    }

    private void Fire()
    {
        if (inputHandler.FireInput && Time.time > unlockTime)
        {
            if (gun[index] is Railgun railgun && Time.time - buttonHoldStartTime >= railgun.Recoil)
            {
                gun[index].Shoot();
                buttonHoldStartTime = Time.time;
            }
            else if (!(gun[index] is Railgun))
            {
                gun[index].Shoot();
                buttonHoldStartTime = 0f;
            }
        }
        else
        {
            buttonHoldStartTime = Time.time;
        }
    }

    private void LockWeapon(float delay)
    {
        unlockTime = Time.time + delay;
    }
}
