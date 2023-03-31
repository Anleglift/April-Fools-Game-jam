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
        if (isLerping == true && lerped == false && finishedLerping == false)
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
        else if (isLerping == false && lerped == true && finishedLerping == false)
        {
            lerpTime += Time.deltaTime * lerpSpeed;
            transform.position = Vector3.Lerp(targetPosition.position, startPosition, lerpTime);

            if (lerpTime >= 1f)
            {
                lerpTime = 0f;
                finishedLerping = true;
            }
        }

        // Only allow button lerping when camera has stopped rotating
        if (finishedLerping && !ButtonPress.isRotating)
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
