using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Timer timer;
    private float damage = 1f;
    public ParticleSystem bloodEffect;

    void Awake()
    {
        timer = GameObject.Find("Timer Panel").GetComponent<Timer>();
        Debug.Log(timer.gameObject.name);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Player")
        {
            timer.takeDamage(damage);
            Instantiate(bloodEffect, collision.gameObject.transform.position, Quaternion.identity, collision.gameObject.transform);
        }
    }
}
