using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class sizeable : MonoBehaviour
{
    bool Enter = false;
    bool scaled = false;
    public Vector3 startScale = Vector3.one;
    public Vector3 endScale = Vector3.one * 10f;
    public float duration = 1f;
    private float timer = 0f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("entered");
            Enter = true;
        }
    }
    private void Update()
    {
        Size();
    }
    private void Size()
    {
        if (Enter && !scaled)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);
            transform.localScale = Vector3.Lerp(startScale, endScale, t);

            if (t == 1f)
            {
                scaled = true;
                timer = 0f;
                Enter = false;
            }
        }
        else if (Enter && scaled)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);
            transform.localScale = Vector3.Lerp(endScale, startScale, t);

            if (t == 1f)
            {
                Enter = false;
                timer = 0f;
                scaled = false;
            }
        }

    }
}
