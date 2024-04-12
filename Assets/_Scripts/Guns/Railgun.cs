using UnityEngine;
using UnityEngine.UI;

public class Railgun : PSManager
{
    [Header("Railgun Settings")]
    [SerializeField, Min(0)] private float recoil = 3f;
    [SerializeField] private Slider redoilSlider;

    private void Awake()
    {
        redoilSlider.maxValue = recoil;
    }

    public float Recoil => recoil;
}
