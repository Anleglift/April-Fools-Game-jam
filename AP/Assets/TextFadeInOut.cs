using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeInOut : MonoBehaviour
{
    public Canvas canvas;
    public float fadeInDuration = 1.0f;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = canvas.GetComponent<CanvasGroup>();
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0f;

        float timeElapsed = 0f;
        while (timeElapsed < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeInDuration);
            canvasGroup.alpha = alpha;
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}
