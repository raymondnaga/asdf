using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {
    public string mainMenuLevel;

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenuLevel);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();
    }
}
