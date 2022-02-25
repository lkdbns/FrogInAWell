using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float greatTime, goodTime, okTime;
    public float currentTime;
    public float health = 3;
    public GameObject[] hearts;
    public string time;
    public bool greatPassed = false;
    public bool goodPassed = false;

    private string healthText;
    private int milliseconds, seconds, minutes;

    void Awake() {
        timer.color = Color.green;
    }
    
    void Update()
    {
        currentTime = Time.timeSinceLevelLoad;

        milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 100;
        seconds = (int)(Time.timeSinceLevelLoad) % 60;
        minutes = (int)(Time.timeSinceLevelLoad / 60f) % 60;

        time = minutes.ToString("D2") + ":" + seconds.ToString("D2") + ":" + milliseconds.ToString("D2");

        timer.text = time;

        if(!greatPassed && currentTime > greatTime) {
            greatPassed = true;
            timer.color = Color.yellow;
        }

        if(!goodPassed && currentTime > goodTime) {
            goodPassed = true;
            timer.color = Color.red;
        }

        if(health <= 0) {
            EndController end = GameObject.Find("End Menu").GetComponent<EndController>();
            end.gameOver();
        }
    }

    public void takeDamage(float damage) {
        health -= damage;
        if(health == 2) {
            hearts[2].SetActive(false);
        }
        else if(health == 1) {
            hearts[2].SetActive(false);
            hearts[1].SetActive(false);
        }
        else {
            hearts[2].SetActive(false);
            hearts[1].SetActive(false);
            hearts[0].SetActive(false);
            EndController end = GameObject.Find("End Menu").GetComponent<EndController>();
            end.gameOver();
        }
    }
}
