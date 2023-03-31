using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leveraction : MonoBehaviour
{
    public GameObject Player;
    public bool Enter;
    public bool On = false;
    public GameObject Lever;
    public Quaternion startRotation;
    public float angle = 60f;
    public float duration = 1f;
    private float timer = 0f;

    private void Start()
    {
        startRotation = Lever.transform.rotation;
    }

    void Update()
    {
        if (Enter)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                On = true;
            }
        }
        if (On)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);
            Quaternion endRotation = Quaternion.AngleAxis(-angle, Vector3.forward) * startRotation;
            Lever.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            Enter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            Enter = false;
    }
}