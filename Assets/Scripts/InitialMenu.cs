using UnityEngine;
using System.Collections;

public class InitialMenu : MonoBehaviour {

    public GameObject pauseButton;
	// Use this for initialization
	void Start () {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))){            
            pauseButton.SetActive(true);
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }

    }
}
