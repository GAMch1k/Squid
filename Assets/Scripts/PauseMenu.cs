using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {


    bool menu_opened = false;

   
    private void Start() {
        HideMenu();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (menu_opened) {
                HideMenu();
            } else {
                OpenMenu();
            }
        }
    }

    public void OpenMenu() {
        Time.timeScale = 0;

        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }

        menu_opened = true;
    }

    public void HideMenu() {

        Time.timeScale = 1;

        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }

        menu_opened = false;
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void RestartGame() {
        SceneManager.LoadScene("Level1");
    }
}
