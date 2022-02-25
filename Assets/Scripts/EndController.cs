using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject timerPanel;
    public GameObject nextLevelButton;
    public GameObject restartButton;
    public Text greatText, goodText, okText;
    public Text currentTimeText;
    public Text congrats;
    public GameObject player;

    private float greatTime, goodTime, okTime;
    // Update is called once per frame

    void Update()
    {
        if(timerPanel == null) {
            timerPanel = GameObject.Find("Timer Panel");

            greatTime = timerPanel.GetComponent<Timer>().greatTime;
            goodTime = timerPanel.GetComponent<Timer>().goodTime;
            okTime = timerPanel.GetComponent<Timer>().okTime;

            greatText.color = Color.green;
            greatText.text = "Great Time\n" + ((int)(greatTime / 60f)).ToString("D2") + ":" + ((int)(greatTime % 60f)).ToString("D2");
            goodText.color = Color.yellow;
            goodText.text = "Good Time\n" + ((int)(goodTime / 60f)).ToString("D2") + ":" + ((int)(goodTime % 60f)).ToString("D2");
            okText.color = Color.red;
            okText.text = "Ok Time\n" + ((int)(okTime / 60f)).ToString("D2") + ":" + ((int)(okTime % 60f)).ToString("D2");
        }
    }

    public void endLevel() {
        currentTimeText.text = timerPanel.GetComponent<Timer>().time;
        changeCurrent();
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        endPanel.SetActive(true);
        timerPanel.SetActive(false);
        if(SceneManager.GetActiveScene().buildIndex < 3) {
            nextLevelButton.SetActive(true);
        }
        player.SetActive(false);
    }

    public void gameOver() {
        currentTimeText.text = timerPanel.GetComponent<Timer>().time;
        changeCurrent();
        congrats.text = "You died with a time of:";
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        endPanel.SetActive(true);
        timerPanel.SetActive(false);
        restartButton.SetActive(true);
        player.SetActive(false);
    }

    public void exitGame() {
        player.SetActive(true);
        Application.Quit();
    }

    public void mainMenu() {
        Debug.Log("Loading Main Menu");
        player.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void nextLevel() {
        player.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restartLevel() {
        player.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void changeCurrent() {
        currentTimeText.text = timerPanel.GetComponent<Timer>().time;

        if(timerPanel.GetComponent<Timer>().greatPassed) {
            currentTimeText.color = Color.yellow;
            congrats.text = "Congratulations! That's a pretty good time:";
        }
        else if(timerPanel.GetComponent<Timer>().goodPassed) {
            currentTimeText.color = Color.red;
            congrats.text = "Good job! You finished with a:";
        }
        else {
            currentTimeText.color = Color.green;
            congrats.text = "Amazing! You're time is great:";
        }
    }

}
