using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float viewSmoothFactor = 10f;
    [SerializeField] float minVerticalAngle = -80f;
    [SerializeField] float maxVerticalAngle = 80f;
    [Space]
    [SerializeField] Transform container;

    [Header("Debug")]
    [SerializeField] bool mouseBlock = false;

    private InputHandler inputHandler;

    private bool invertYAxis = false;
    private float verticalRotation;

    private void Start()
    {
        inputHandler = InputHandler.Instance;
    }

    private void Update()
    {
        HandlerRotation();

        if (mouseBlock) MouseBlock();
    }

    void HandlerRotation()
    {
        float mouseYInput = invertYAxis ? -inputHandler.LookInput.y : inputHandler.LookInput.y;

        float mouseXRotation = inputHandler.LookInput.x * mouseSensitivity * viewSmoothFactor;

        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= mouseYInput * mouseSensitivity * viewSmoothFactor;

        container.localRotation = Quaternion.Euler(Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle), 0, 0);

    }

    void MouseBlock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
