using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Skybox Settings")]
    [SerializeField] private Texture2D skyboxSunrise;
    [SerializeField] private Texture2D skyboxDay;
    [SerializeField] private Texture2D skyboxSunset;
    [SerializeField] private Texture2D skyboxNight;

    [Header("Light Settings")]
    [SerializeField] private Light globalLight;
    [Space]
    [SerializeField] private Gradient gradientNightToSunrise;
    [SerializeField] private Gradient gradientSunriseToDay;
    [SerializeField] private Gradient gradientDayToSunset;
    [SerializeField] private Gradient gradientSunsetToNight;

    [Header("Time Settings")]
    [SerializeField, Range(1, 24), Tooltip("In minutes")] private int lengthOfTheDay = 3;

    [Header("VFX")]
    [SerializeField, Min(0)] private float transitionDuration = 10f;

    private int minuts;
    private int hours = 0;

    private float tempSecond = 0;
    private float timeScale;

    private void Awake()
    {
        timeScale = 1440 / (lengthOfTheDay * 60);
    }

    public void Update()
    {
        tempSecond += Time.deltaTime * timeScale;
        if (tempSecond >= 1)
        {
            Minuts++;
            tempSecond = 0;
        }
    }

    void OnMinutesChange(int value)
    {
        globalLight.transform.Rotate(Vector3.up, (1f / 1440f) * 360f, Space.World);
        if (minuts >= 60)
        {
            Hours++;
            Minuts = 0;
        }
        if (hours >= 24)
        {
            Hours = 0;
        }
    }

    void OnHoursChange(int value)
    {
        switch (value)
        {
            case 6:
                StopAllCoroutines();
                StartCoroutine(LerpSkybox(skyboxNight, skyboxSunrise, transitionDuration * timeScale));
                StartCoroutine(LerpLight(gradientNightToSunrise, transitionDuration * timeScale));
                break;
            case 8:
                StopAllCoroutines();
                StartCoroutine(LerpSkybox(skyboxSunrise, skyboxDay, transitionDuration * timeScale));
                StartCoroutine(LerpLight(gradientSunriseToDay, transitionDuration * timeScale));
                break;
            case 18:
                StopAllCoroutines();
                StartCoroutine(LerpSkybox(skyboxDay, skyboxSunset, transitionDuration * timeScale));
                StartCoroutine(LerpLight(gradientDayToSunset, transitionDuration * timeScale));
                break;
            case 22:
                StopAllCoroutines();
                StartCoroutine(LerpSkybox(skyboxSunset, skyboxNight, transitionDuration * timeScale));
                StartCoroutine(LerpLight(gradientSunsetToNight, transitionDuration * timeScale));
                break;
        }
    }

    private IEnumerator LerpSkybox(Texture2D a, Texture2D b, float time)
    {
        RenderSettings.skybox.SetTexture("_Texture1", a);
        RenderSettings.skybox.SetTexture("_Texture2", b);
        RenderSettings.skybox.SetFloat("_Blend", 0);

        for (float i = 0; i < time; i += Time.deltaTime * timeScale)
        {
            RenderSettings.skybox.SetFloat("_Blend", i / time);
            yield return null;
        }

        RenderSettings.skybox.SetTexture("_Texture1", b);
    }

    private IEnumerator LerpLight(Gradient lightGradient, float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime * timeScale)
        {
            globalLight.color = lightGradient.Evaluate(i / time);
            RenderSettings.fogColor = globalLight.color;
            yield return null;
        }
    }

    public int Minuts { get => minuts; set { minuts = value; OnMinutesChange(value); } }
    public int Hours { get => hours; set { hours = value; OnHoursChange(value); } }
}
