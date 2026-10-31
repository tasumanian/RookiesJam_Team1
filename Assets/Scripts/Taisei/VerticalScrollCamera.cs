using UnityEngine;
public class VerticalScrollCamera : MonoBehaviour
{
    [SerializeField]
    private Camera targetCamera;

    // 基準となるアスペクト比
    // 16:9
    [SerializeField]
    private float baseAspect = 16f / 9f;

    // 16:9のときにちょうどいいSize
    [SerializeField]
    private float baseOrthographicSize = 14f;

    private void Start()
    {
        UpdateCameraSize();
    }

    private void UpdateCameraSize()
    {
        float currentAspect =
            (float)Screen.width / Screen.height;

        targetCamera.orthographicSize =
            baseOrthographicSize *
            (baseAspect / currentAspect);
    }
}