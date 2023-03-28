using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Hitbox1 Hitbox1;
    public GameObject Door;
    public Quaternion startRotation;
    public Quaternion endRotation;
    public float duration = 1f;
    private float timer = 0f;
    public bool Open = false;
    private bool isOpening = false;
    private bool isClosing = false;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = Door.transform.rotation;
        endRotation = Quaternion.Euler(0f, startRotation.y + 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // check if the player has entered the hitbox and request the door to open
        if (Hitbox1.Enter && !isOpening && !isClosing && Open == false)
        {
            isOpening = true;
        }
        // check if the player has left the hitbox and request the door to close
        if (Hitbox1.Enter == false && !isOpening && !isClosing && Open == true)
        {
            isClosing = true;
        }
        // update the door rotation if it is currently opening
        if (isOpening)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);
            Door.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            if (t == 1f)
            {
                timer = 0f;
                Open = true;
                isOpening = false;
            }
        }
        // update the door rotation if it is currently closing
        if (isClosing)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);
            Door.transform.rotation = Quaternion.Lerp(endRotation, startRotation, t);
            if (t == 1f)
            {
                timer = 0f;
                Open = false;
                isClosing = false;
            }
        }
    }
}
