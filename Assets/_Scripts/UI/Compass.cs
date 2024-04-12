using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    [Header("Compass Settings")]
    [SerializeField] Transform player;

    RawImage compassImage;

    private void Start()
    {
        compassImage = GetComponent<RawImage>();
    }

    void Update()
    {
        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);
    }
}
