using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MenuNavigation : MonoBehaviour
{
    [Header("Menu Navigation")]
    [SerializeField] Camera menuCamera;
    [SerializeField] List<Transform> menuPositions = new();
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float movementSmooth = 10f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float rotationSmooth = 10f;

    [Header("Default Selected Object")]
    [SerializeField] GameObject defaultSelectedObject;
    Vector3 currentVelocity = Vector3.zero;

    int index = 2;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(defaultSelectedObject);
    }

    private void Update()
    {
        if (Gamepad.current != null && Gamepad.current.wasUpdatedThisFrame && EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(defaultSelectedObject);
        }

        if (menuPositions.Count < 1) return;

        switch (index)
        {
            case 0:
                CameraMovement(menuPositions[0]);
                break;
            case 1:
                CameraMovement(menuPositions[1]);
                break;
            case 2:
                CameraMovement(menuPositions[2]);
                break;
        }
    }

    private void CameraMovement(Transform target)
    {
        target.GetPositionAndRotation(out Vector3 targetPosition, out Quaternion targetRotation);

        menuCamera.transform.SetPositionAndRotation(
            Vector3.SmoothDamp(menuCamera.transform.position, targetPosition, ref currentVelocity, 1f / (movementSpeed + movementSmooth), Mathf.Infinity, Time.deltaTime),
            Quaternion.Lerp(menuCamera.transform.rotation, targetRotation, 1f / (rotationSpeed + rotationSmooth) * Time.deltaTime)
            );
    }

    public void OptionsPanel()
    {
        index = 0;
    }

    public void CreditsPanel()
    {
        index = 1;
    }

    public void DefaultPanel()
    {
        index = 2;
    }
}
