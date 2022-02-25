using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject timerPanel;
    public Text greatText, goodText, okText;
    public Text currentTimeText;
    public GameObject player;
    private bool isPaused = false;

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

        if(Input.GetKeyDown(KeyCode.Escape)) {
            pause();
        }

        if(Time.timeScale == 0) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void pause() {
        if(!isPaused) {
            isPaused = true;
            currentTimeText.text = timerPanel.GetComponent<Timer>().time;
            changeCurrent();
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.SetActive(false);
            pausePanel.SetActive(true);
            timerPanel.SetActive(false);
        }
        else {
            isPaused = false;
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            pausePanel.SetActive(false);
            timerPanel.SetActive(true);
            player.SetActive(true);
        }
        
    }

    public void exitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void mainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void changeCurrent() {
        currentTimeText.text = timerPanel.GetComponent<Timer>().time;

        if(timerPanel.GetComponent<Timer>().greatPassed) {
            currentTimeText.color = Color.yellow;
        }
        else if(timerPanel.GetComponent<Timer>().goodPassed) {
            currentTimeText.color = Color.red;
        }
        else {
            currentTimeText.color = Color.green;
        }
    }
}
