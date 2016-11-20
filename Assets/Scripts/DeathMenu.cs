using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathMenu : InGameMenu {
    public GameObject pauseButton;
    private AudioController audio;

    void Start()
    {
        audio = FindObjectOfType<AudioController>();
        pauseButton.SetActive(false);
    }

    public void RestartGame()
    {
        base.RestartGame();
        pauseButton.SetActive(true);
    }
}
