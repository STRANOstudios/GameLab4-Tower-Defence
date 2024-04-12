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

    private InputHandler inputHandler;

    private bool invertYAxis = false;
    private float verticalRotation;
    private bool isPause = false;
    private bool isShopOpen = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inputHandler = InputHandler.Instance;
    }

    private void Update()
    {
        if (isPause || isShopOpen) return;

        HandlerRotation();
    }

    private void OnEnable()
    {
        LevelManager.pause += Pause;
        GameplaySettings.settings += Settings;
        WaveManager.Shop += Shop;
        ShopManager.Return += Shop;
    }

    private void OnDisable()
    {
        LevelManager.pause -= Pause;
        GameplaySettings.settings -= Settings;
        WaveManager.Shop -= Shop;
        ShopManager.Return -= Shop;
    }

    void Pause()
    {
        isPause = !isPause;
    }

    void Shop()
    {
        isShopOpen = !isShopOpen;
    }

    void HandlerRotation()
    {
        float mouseYInput = invertYAxis ? -inputHandler.LookInput.y : inputHandler.LookInput.y;

        float mouseXRotation = inputHandler.LookInput.x * mouseSensitivity * viewSmoothFactor;

        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= mouseYInput * mouseSensitivity * viewSmoothFactor;

        container.localRotation = Quaternion.Euler(Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle), 0, 0);
    }

    void Settings(float controllerSen, bool invertY)
    {
        invertYAxis = invertY;
        mouseSensitivity = controllerSen;
    }
}
