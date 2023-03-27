using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public Transform Room;
    public GameObject player;
    public bool insideHitBox;
    public float turnSpeed = 10f;

    // Roteste camera cu 45 de grade
    void Rotatie()
    {
        if (Input.GetKey(KeyCode.E) == true)
        {
            Room.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        insideHitBox = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (insideHitBox == true) 
        {
            Rotatie();
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
        if (other.gameObject == player)
        {
            insideHitBox = false;
        }
    }
}
