using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Timer timer;
    public float damage;

    void Awake() {
        timer = GameObject.Find("Timer Panel").GetComponent<Timer>();
        Debug.Log(timer.gameObject.name);
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            timer.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
