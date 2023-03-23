using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnWaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    public leveraction leveraction;
    public float speed = 5f;
    public float smoothTime = 0.5f;

    private Rigidbody rb;
    private int currentWaypointIndex = 0;
    private int waypointCount;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        transform.position = waypoints[currentWaypointIndex].transform.position;
        rb = GetComponent<Rigidbody>();
        waypointCount = waypoints.Length;
    }

    private void FixedUpdate()
    {
        if (leveraction.On)
        {
            Vector3 destination = waypoints[currentWaypointIndex + 1].transform.position;
            Vector3 direction = (destination - transform.position).normalized;
            float distanceToDestination = Vector3.Distance(transform.position, destination);

            if (distanceToDestination > 0.1f)
            {
                float targetSpeed = Mathf.Lerp(0, speed, distanceToDestination / 2);
                rb.MovePosition(transform.position + direction * targetSpeed * Time.fixedDeltaTime);
            }
            else
            {
                currentWaypointIndex++;
                if (currentWaypointIndex == waypointCount - 1)
                {
                    currentWaypointIndex = -1;
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
