using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject controlMenu;
    public GameObject levelSelectMenu;
    public GameObject mainMenu;

    public void loadLevel(int level) {
        SceneManager.LoadScene(level);
    }

    public void startGame() {
        loadLevel(1);
    }

    public void exitGame() {
        Application.Quit();
    }

    private void changeMenu(GameObject fromMenu, GameObject toMenu) {
        fromMenu.SetActive(false);
        toMenu.SetActive(true);
    }

    // public void buttonChangeMenu(GameObject toMenu) {
    //     gameObject.transform.parent.gameObject.SetActive(false);
    //     toMenu.SetActive(true);
    // }

    public void loadControls() {
        changeMenu(mainMenu, controlMenu);
    }

    public void loadLevelSelect() {
        changeMenu(mainMenu, levelSelectMenu);
    }

    public void loadMaimFromControls() {
        changeMenu(controlMenu, mainMenu);
    }

    public void loadMaimFromLevel() {
        changeMenu(levelSelectMenu, mainMenu);
    }
}
