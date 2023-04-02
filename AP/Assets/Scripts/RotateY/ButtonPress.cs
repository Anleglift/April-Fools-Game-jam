using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public Transform Room;
    public GameObject player;
    public bool insideHitBox;
    public float rotationSpeed = 1.0f;
    public float targetAngle = 0.0f;
    public bool isRotating = false;
    public bool CanRotate = false;
    public bool finishedLerp = true;
    public GameObject PlayerRB;
    public AudioSource Press;
    // Start is called before the first frame update
    void Start()
    {
        insideHitBox = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (insideHitBox == true)
        {
            if (Input.GetKeyDown(KeyCode.E) )
            {
               
                PlayerRB.GetComponent<Rigidbody>().isKinematic = true;
                CanRotate = true;
                finishedLerp = false;
            }
            if (CanRotate==true && !isRotating)
            { 
                Press.Play();
                targetAngle += 90.0f;
                if (targetAngle >= 360.0f)
                {
                    targetAngle -= 360.0f;
                }
                isRotating = true;
            }

            if (isRotating)
            {
                float currentAngle = Room.transform.rotation.eulerAngles.y;
                float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
                Room.transform.rotation = Quaternion.Euler(0.0f, newAngle, 0.0f);

                if (Mathf.Abs(newAngle - targetAngle) < 0.01f)
                {
                    PlayerRB.GetComponent<Rigidbody>().isKinematic = false;
                    CanRotate =false;
                    isRotating = false;
                    finishedLerp= true; 
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            insideHitBox = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player && !isRotating)
        {
            insideHitBox = false;
        }
    }
}