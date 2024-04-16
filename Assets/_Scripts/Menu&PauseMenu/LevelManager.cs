using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField, Tooltip("The name of the scene of main menu")] private string MainMenu;

    private InputHandler inputHandler;

    private bool isPaused = false;
    private bool pauseIsActive = true;

    public delegate void PauseAction();
    public static event PauseAction pause;

    private void Start()
    {
        inputHandler = InputHandler.Instance;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        MenuController.resume += Resume;
        Hp.death += Death;
    }

    private void OnDisable()
    {
        MenuController.resume -= Resume;
        Hp.death -= Death;
    }

    private void Update()
    {
        Escape();
    }

    private void Escape()
    {

        if (inputHandler.EscapeInput && pauseIsActive)
        {
            StartCoroutine(Delay(0.3f));
            isPaused = !isPaused;
            Pause(isPaused);
        }
    }

    private void Resume()
    {
        isPaused = false;
        Pause(isPaused);
    }

    private void Pause(bool value)
    {
        Time.timeScale = value ? 0 : 1;
        pauseMenu.SetActive(value);
        Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = value;

        pause?.Invoke();
    }

    private IEnumerator Delay(float value = 1f)
    {
        pauseIsActive = false;
        yield return new WaitForSecondsRealtime(value);
        pauseIsActive = true;
    }

    private void Death()
    {
#if UNITY_EDITOR
        SceneManager.LoadScene(MainMenu);
#else
        SceneManager.LoadScene(0);
#endif
        GameManager.Instance.PlayMusic();
    }
}
