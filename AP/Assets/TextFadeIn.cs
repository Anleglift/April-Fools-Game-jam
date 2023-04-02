using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFadeIn : MonoBehaviour
{
    public float fadeInDuration = 2f;  // The duration of the fade-in effect in seconds
    public TextMeshPro textMeshPro;  // Reference to the TextMeshPro component

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        // Set the alpha of the text to zero
        textMeshPro.alpha = 0f;

        // Gradually increase the alpha of the text over the specified duration
        float timeElapsed = 0f;
        while (timeElapsed < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeInDuration);
            textMeshPro.alpha = alpha;
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Set the alpha of the text to one (fully opaque)
        textMeshPro.alpha = 1f;
    }
}