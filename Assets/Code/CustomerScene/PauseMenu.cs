using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseMenu : MonoBehaviour {
    public GameObject pausePanel;
    private bool paused = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            paused = !paused;
            pausePanel.SetActive(paused);
            Time.timeScale = paused ? 0 : 1;
        }
    }

    public void Resume() {
        paused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
