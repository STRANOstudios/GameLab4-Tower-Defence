using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float viewSmoothFactor = 10f;

    [Header("Debug")]
    [SerializeField] bool mouseBlock = false;

    private InputHandler inputHandler;

    private bool invertYAxis = false;
    private float verticalRotation;

    private void Awake()
    {
        inputHandler = InputHandler.Instance;
    }

    private void Update()
    {
        HandlerRotation();

        if (mouseBlock) MouseBlock();

        Debug.Log(inputHandler.LookInput);
    }

    void HandlerRotation()
    {
        float mouseYInput = invertYAxis ? -inputHandler.LookInput.y : inputHandler.LookInput.y;

        float mouseXRotation = inputHandler.LookInput.x * mouseSensitivity * viewSmoothFactor;

        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= mouseYInput * mouseSensitivity;

        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void MouseBlock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
