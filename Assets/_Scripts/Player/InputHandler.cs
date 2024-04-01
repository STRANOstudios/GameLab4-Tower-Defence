using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Name Rederences")]
    [SerializeField] private string actionMapName = "Input";

    [Header("Action Name Refernces")]
    [SerializeField] private string look = "Movement";

    private InputAction lookAction;

    public Vector2 LookInput { get; private set; }

    public static InputHandler Instance { get; private set; }

    private void Awake()
    {
        #region Singleton

        if (Instance != null)
        {
            Destroy(transform.root.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(transform.root.gameObject);

        #endregion

        lookAction = playerControls.FindActionMap(actionMapName).FindAction(look);

        RegisterInputActions();
    }

    void RegisterInputActions()
    {
        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => LookInput = Vector2.zero;
    }

    private void OnEnable()
    {
        lookAction.Enable();
    }

    private void OnDisable()
    {
        lookAction.Disable();
    }
}
