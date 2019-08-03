using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance = null;
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    private Transform camTransform;
    public Canvas canvas;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        if (camTransform == null)
        {
            camTransform = Camera.main.transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    public void Shake(float duration)
    {
        shakeDuration = duration;
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.renderMode = RenderMode.WorldSpace;
        while (shakeDuration > 0)
        {
            print(camTransform.localPosition);
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
            yield return null;
        }
        shakeDuration = 0f;
        camTransform.localPosition = originalPos;
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
    }
}