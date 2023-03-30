using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTransition : MonoBehaviour
{
    public Transform targetPosition;
    public float lerpSpeed = 1f;
    public ButtonPress ButtonPress;
    private Vector3 startPosition;
    private bool isLerping = false;
    private float lerpTime = 0f;
    private bool lerped = false;
    private bool finishedLerping = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (isLerping && !lerped && finishedLerping == false)
        {
            lerpTime += Time.deltaTime * lerpSpeed;
            transform.position = Vector3.Lerp(startPosition, targetPosition.position, lerpTime);

            if (lerpTime >= 1f)
            {
                isLerping = false;
                lerpTime = 0f;
                lerped = true;
            }
        }
        else if (lerped && finishedLerping == false)
        {
            lerpTime += Time.deltaTime * lerpSpeed;
            transform.position = Vector3.Lerp(targetPosition.position, startPosition, lerpTime);

            if (lerpTime >= 1f)
            {
                isLerping = true;
                lerpTime = 0f;
                lerped = false;
                finishedLerping = true;
            }
        }
        if (finishedLerping && ButtonPress.isRotating == false)
        {
            if (ButtonPress.insideHitBox && Input.GetKeyDown(KeyCode.E))
            {
                isLerping = true;
                lerped = false;
                finishedLerping = false;
            }
        }
    }

}
