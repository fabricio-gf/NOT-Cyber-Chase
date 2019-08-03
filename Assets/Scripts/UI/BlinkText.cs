using System.Collections;
using TMPro;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    TextMeshProUGUI myText;

    float currentTime;
    public float blinkDuration;

    Color initialAlpha;
    public Color targetAlpha;

    bool isFading = true;

    private void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        initialAlpha = myText.color;
    }

    IEnumerator Fade(float FadeDelay)
    {

        yield return null;
    }
}
