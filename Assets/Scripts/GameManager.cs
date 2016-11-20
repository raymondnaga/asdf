using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    private GameObjectController[] controllers;
    public DeathMenu theDeathScreen;

    void Start()
    {
        controllers = FindObjectsOfType<GameObjectController>();
        //Debug.Log(controllers.Length);
    }

    public void RestartGame()
    {
        theDeathScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        for(int i = 0; i < controllers.Length; i++)
        {
            controllers[i].reset();
        }
        //yield return new WaitForSeconds(0.5f);
    }
}
