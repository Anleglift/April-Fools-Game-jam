using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Transition : MonoBehaviour
{
    public PostProcessVolume volume1;
    public PostProcessVolume volume2;
    public float duration = 2.0f;
    public GameObject player;
    public bool CanTransition= true;
    private bool isTransitioning = false;
    private float t = 0.0f;
    public GameObject myObject;
    public AudioSource collect;
    void Start()
    {
        volume1.weight = 1.0f;
        volume2.weight = 0.0f;
    }

    void Update()
    { 
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (CanTransition)
            {
                collect.Play();
            }
            Renderer renderer = myObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
            StartTransition();
        }

    }
    public void StartTransition()
    {
        if (!isTransitioning && CanTransition)
        {
            CanTransition = false;
            isTransitioning = true;
            t = 0.0f;
        }
    }
}
