using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leveraction : MonoBehaviour
{
    public GameObject Player;
    public bool Enter;
    public bool On = false;
    public bool CanPress = true;

    void Start()
    {

    }


    void Update()
    {
        if (Enter)
        {
            if (Input.GetKeyDown(KeyCode.E) && CanPress)
            {
                if (On == false)
                    On = true;
                else On = false;
                CanPress = false;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (other.gameObject == Player)
            Enter = true;

    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.gameObject == Player)
        {
            Enter = false;
            CanPress = true;
        }
    }


}