using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]
    [SerializeField, Tooltip("The name of the scene to be loaded")] private string sceneToBeLoad;

    public delegate void Resume();
    public static event Resume resume;

    #region Menu Buttons

    public void PlayButton()
    {
#if UNITY_EDITOR
        SceneManager.LoadScene(sceneToBeLoad);
#else
        SceneManager.LoadScene(1);
#endif
        GameManager.Instance.PlayMusic(true);
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ReturnButton()
    {
#if UNITY_EDITOR
        SceneManager.LoadScene(sceneToBeLoad);
#else
        SceneManager.LoadScene(0);
#endif
        GameManager.Instance.PlayMusic();
    }

    public void ResumeButton()
    {
        resume?.Invoke();
    }

    #endregion

}
