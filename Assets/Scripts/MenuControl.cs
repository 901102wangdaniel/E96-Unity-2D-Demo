using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    

    public static bool isPaused = true;
    public GameObject pauseMenu;
    public GameObject HUD;


    public void SceneSwapper(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void Pause() {
        if (!isPaused) {
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
            HUD.SetActive(false);
        } else {
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
            HUD.SetActive(true);
        }
    }
}
