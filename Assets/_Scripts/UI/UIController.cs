using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text score;
    [SerializeField] private Slider healthbar;
    [SerializeField] private List<GameObject> guns;

    private GameObject selectedGun = null;

    private void Start()
    {
        UpdateGuns(0);
    }

    private void OnEnable()
    {
        Hp.hit += UpdateHealthBar;
        Score.point += UpdateScore;
        ShootingManager.IndexGun += UpdateGuns;
    }

    private void OnDisable()
    {
        Hp.hit -= UpdateHealthBar;
        Score.point -= UpdateScore;
        ShootingManager.IndexGun -= UpdateGuns;
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
        if (selectedGun) selectedGun.SetActive(false);
        selectedGun = guns[index];
        selectedGun.SetActive(true);
    }
}
