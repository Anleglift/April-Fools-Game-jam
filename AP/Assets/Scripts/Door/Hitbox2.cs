using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox2 : MonoBehaviour
{
    public GameObject hitbox;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            Destroy(hitbox);
    }
}
