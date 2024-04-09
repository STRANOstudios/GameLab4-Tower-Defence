using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] AudioClip music;

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
        audioSource.clip = music;
    }

    public void PlayMusic(AudioClip clip)
    {
        audioSource.clip = clip;
    }
}
