using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private void Start()
    {
        transform.rotation = Camera.main.transform.rotation;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = transform.TransformDirection(Vector3.forward);
        rb.velocity = moveDirection * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
            Destroy(gameObject);
    }
}
