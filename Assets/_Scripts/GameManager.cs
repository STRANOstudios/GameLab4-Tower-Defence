using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] AudioClip mainMenu;
    [SerializeField] AudioClip game;

    private AudioSource audioSource;

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

        audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    public void PlayMusic(bool value = false)
    {
        if (audioSource && game && value)
        {
            audioSource.Stop();
            audioSource.clip = game;
            audioSource.Play();
        }
        else if (audioSource && mainMenu)
        {
            audioSource.Stop();
            audioSource.clip = mainMenu;
            audioSource.Play();
        }
    }
}
