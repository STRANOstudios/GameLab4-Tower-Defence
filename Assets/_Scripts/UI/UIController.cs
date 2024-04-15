using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UIController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text score;
    [SerializeField] private Slider healthbar;
    [SerializeField] private TMP_Text wavesCount;
    [SerializeField] private List<GameObject> guns;
    [SerializeField] private List<GameObject> gunsFlags;
    [SerializeField] private List<GameObject> gunsFlagsActive;
    [SerializeField, Min(0)] private int indentationSize = 0;

    private int oldIndex = 0;
    private Vector3 origin;

    private void Start()
    {
        UpdateGuns(oldIndex);
    }

    private void OnEnable()
    {
        Hp.hit += UpdateHealthBar;
        Score.point += UpdateScore;
        ShootingManager.IndexGun += UpdateGuns;
        WaveManager.WaveIndex += UpdateWavesCount;
    }

    private void OnDisable()
    {
        Hp.hit -= UpdateHealthBar;
        Score.point -= UpdateScore;
        ShootingManager.IndexGun -= UpdateGuns;
        WaveManager.WaveIndex -= UpdateWavesCount;
    }

    void UpdateHealthBar(float health)
    {
        if (health > healthbar.maxValue) healthbar.maxValue = health;
        healthbar.value = health;
    }

    void UpdateScore(int value)
    {
        score.text = value.ToString("D6");
    }

    void UpdateGuns(int index)
    {
        guns[oldIndex].SetActive(false);
        gunsFlags[oldIndex].SetActive(true);
        gunsFlagsActive[oldIndex].SetActive(false);

        guns[index].SetActive(true);
        gunsFlags[index].SetActive(false);
        gunsFlagsActive[index].SetActive(true);

        oldIndex = index;
    }

    void UpdateWavesCount(int value)
    {
        wavesCount.text = value.ToString("D3");
    }
}
