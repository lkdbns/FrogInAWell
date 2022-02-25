using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform[] waypoints;
    int current = 0;
    public float speed = 3f;
    float radius = 1f;

    private void Start()
    {
        transform.position = waypoints[0].position;
    }

    private void Update()
    {
        if (Vector3.Distance(waypoints[current].position, transform.position) < radius)
        {
            current++;
            if (current >= waypoints.Length)
                current = 0;
        }
        transform.position = Vector3.Lerp(transform.position, waypoints[current].position, speed * Time.deltaTime);
    }
}
