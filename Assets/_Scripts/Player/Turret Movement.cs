using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretMovement : MonoBehaviour
{
    Input input=null;
    Vector2 Rotation;
    [SerializeField] float rotationSpeed;
    float xRot, yRot;

    private void Awake()
    {
        input=new Input();
        Rotation= Vector2.zero;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += SxDxRotation;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= SxDxRotation;
    }

    private void SxDxRotation(InputAction.CallbackContext value)
    {
        Rotation = value.ReadValue<Vector2>();
        Rotation.Normalize();
        Debug.Log(Rotation);
        transform.Rotate(new Vector3(Rotation.y,Rotation.x,0));
    }



}
