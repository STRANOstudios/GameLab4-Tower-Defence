using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Name Rederences")]
    [SerializeField] private string actionMapNamePlayer = "Player";
    [SerializeField] private string actionMapNameSystem = "System";

    [Header("Action Name Refernces")]
    [SerializeField] private string look = "Movement";
    [SerializeField] private string fire = "Fire";
    [SerializeField] private string scroll = "Scroll";
    [SerializeField] private string escape = "Escape";

    private InputAction lookAction;
    private InputAction fireAction;
    private InputAction scrollAction;
    private InputAction escapeAction;

    public Vector2 LookInput { get; private set; }
    public float ScrollInput { get; private set; }
    public bool FireInput { get; private set; }
    public bool EscapeInput { get; private set; }

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

        lookAction = playerControls.FindActionMap(actionMapNamePlayer).FindAction(look);
        fireAction = playerControls.FindActionMap(actionMapNamePlayer).FindAction(fire);
        scrollAction = playerControls.FindActionMap(actionMapNamePlayer).FindAction(scroll);
        escapeAction = playerControls.FindActionMap(actionMapNameSystem).FindAction(escape);

        RegisterInputActions();
    }

    void RegisterInputActions()
    {
        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => LookInput = Vector2.zero;

        fireAction.performed += context => FireInput = true;
        fireAction.canceled += context => FireInput = false;

        scrollAction.performed += context => ScrollInput = context.ReadValue<float>();
        scrollAction.canceled += context => ScrollInput = 0f;

        escapeAction.performed += context => EscapeInput = true;
        escapeAction.canceled += context => EscapeInput = false;
    }

    private void OnEnable()
    {
        lookAction.Enable();
        fireAction.Enable();
        scrollAction.Enable();

        escapeAction.Enable();
    }

    private void OnDisable()
    {
        lookAction.Disable();
        fireAction.Disable();
        scrollAction.Disable();

        escapeAction.Disable();
    }
}
