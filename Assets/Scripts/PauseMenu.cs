using UnityEngine;
using System.Collections;

public class PauseMenu : InGameMenu {

    public string mainMenuLevel;

    public GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        base.RestartGame();
        pauseMenu.SetActive(false);
    }

    public void QuitToMain()
    {
        base.QuitToMain();
        pauseMenu.SetActive(false);
    }
}
