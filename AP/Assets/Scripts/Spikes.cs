using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public GameObject DeathScreen;
    public GameObject player;
    public GameObject Gun;
    private bool Dead;
    public CanvasGroup canvasGroup;
    public float startAlpha = 1.0f;
    public float endAlpha = 0.0f;
    public float duration = 1.0f;

    private bool triggered = false;
    private float timeElapsed = 0.0f;
    void Update()
    {
        if (triggered)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / duration);
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, t);

            if (t >= 1.0f)
            {
                triggered = false;
                timeElapsed = 0.0f;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == player)
        {
            Destroy(player);
            Destroy(Gun);
            triggered = true;
            Invoke("Reload", 5f);
        }
    }
    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
