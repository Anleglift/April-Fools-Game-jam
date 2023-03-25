using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Transition : MonoBehaviour
{
    public PostProcessVolume volume1;
    public PostProcessVolume volume2;
    public float duration = 2.0f;

    private bool isTransitioning = false;
    private float t = 0.0f;

    void Start()
    {
        volume1.weight = 1.0f;
        volume2.weight = 0.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartTransition();
        }

        if (isTransitioning)
        {
            t += Time.deltaTime / duration;
            volume1.weight = Mathf.Lerp(1.0f, 0.0f, t);
            volume2.weight = Mathf.Lerp(0.0f, 1.0f, t);
            if (t >= 1.0f)
            {
                isTransitioning = false;
            }
        }
    }

    public void StartTransition()
    {
        if (!isTransitioning)
        {
            isTransitioning = true;
            t = 0.0f;
        }
    }
}
