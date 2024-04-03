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

    private int minuts;
    private int hours;

    private float tempSecond = 0;

    public void Update()
    {
        tempSecond += Time.deltaTime * (1440 / (lengthOfTheDay * 60));
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
                StartCoroutine(LerpSkybox(skyboxNight, skyboxSunrise, 10f));
                StartCoroutine(LerpLight(gradientNightToSunrise, 10f));
                break;
            case 8:
                StartCoroutine(LerpSkybox(skyboxSunrise, skyboxDay, 10f));
                StartCoroutine(LerpLight(gradientSunriseToDay, 10f));
                break;
            case 18:
                StartCoroutine(LerpSkybox(skyboxDay, skyboxSunset, 10f));
                StartCoroutine(LerpLight(gradientDayToSunset, 10f));
                break;
            case 22:
                StartCoroutine(LerpSkybox(skyboxSunset, skyboxNight, 10f));
                StartCoroutine(LerpLight(gradientSunsetToNight, 10f));
                break;
        }
    }

    private IEnumerator LerpSkybox(Texture2D a, Texture2D b, float time)
    {
        RenderSettings.skybox.SetTexture("_Texture1", a);
        RenderSettings.skybox.SetTexture("_Texture2", a);
        RenderSettings.skybox.SetFloat("_Blend", 0);
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            RenderSettings.skybox.SetFloat("_Blend", i / time);
            yield return null;
        }
        RenderSettings.skybox.SetTexture("_Texture1", b);
    }

    private IEnumerator LerpLight(Gradient lightGradient, float time)
    {
        for (float i = 0; i < time; i += Time.deltaTime)
        {
            globalLight.color = lightGradient.Evaluate(i / time);
            RenderSettings.fogColor = globalLight.color;
            yield return null;
        }
    }

    public int Minuts { get => minuts; set { minuts = value; OnMinutesChange(value); } }
    public int Hours { get => hours; set { hours = value; OnHoursChange(value); } }
}
