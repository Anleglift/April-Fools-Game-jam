using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Vector3 localPosition;
    public GameObject bullet;
    public bool CanShoot;
    private float delay = 2f;
    public AudioSource ShootSound;
    private void Start()
    {
         CanShoot = true;
    }
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = localPosition;
        if (Input.GetMouseButtonDown(0) && CanShoot)
        {
            ShootSound.Play();
            Instantiate(bullet, transform.position, Camera.main.transform.rotation);
            CanShoot=false;  
            Invoke("ResetShoot",delay);
        }
    }
    private void ResetShoot()
    {
        CanShoot = true;
    }
}