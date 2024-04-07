using UnityEngine;

public class Zoom : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Camera firstPersonCamera;
    [Space]
    [SerializeField] private float smooth = 0f;
    [SerializeField, Range(0f, 179f)] private float minZoom = 30f;
    [SerializeField, Range(0f, 179f)] private float defaultZoom = 60f;

    private InputHandler inputHandler;

    private void Start()
    {
        inputHandler = InputHandler.Instance;
    }

    private void Update()
    {
        ZoomMethod();
    }

    private void ZoomMethod()
    {
        if (inputHandler.ZoomInput > 0)
        {
            firstPersonCamera.fieldOfView = Mathf.Lerp(firstPersonCamera.fieldOfView, minZoom, smooth * Time.deltaTime);
        }
        else if (firstPersonCamera.fieldOfView < defaultZoom)
        {
            firstPersonCamera.fieldOfView = Mathf.Lerp(firstPersonCamera.fieldOfView, defaultZoom, smooth * Time.deltaTime);
        }
    }
}
