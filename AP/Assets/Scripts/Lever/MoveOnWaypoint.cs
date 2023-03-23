using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnWaypoint : MonoBehaviour
{
    public leveraction leveraction;
    public List<GameObject> waypoints;
    public float speed = 5;
    int index = 0;
    public bool loop = true;


    void Update()
    {
        if (leveraction.On)
        {
            Vector3 destination = waypoints[index].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.05)
            {
                if (index < waypoints.Count - 1)
                    index++;
                else
                {
                    if (loop)
                    {
                        index = 0;
                    }

                }
            }
        }

    }
}