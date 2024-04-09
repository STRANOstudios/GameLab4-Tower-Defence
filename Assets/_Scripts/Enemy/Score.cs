using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField, Tooltip("Score value")] private int score = 0;

    public delegate void Point(int value);
    public static event Point point = null;

    private void OnDisable()
    {
        point?.Invoke(score);
    }
}
