using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox1 : MonoBehaviour
{
    public bool Enter;
    public GameObject player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Enter=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            Enter = false;
        }
    }
}
