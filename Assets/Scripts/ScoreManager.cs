using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text ScoreText;
    public Text HighScoreText;
    static private long highScore;
    private PlayerController player;

	// Use this for initialization
	void Start () {
        highScore=PlayerPrefs.GetInt("highscore", 0);
        HighScoreText.text = "High Score: " + highScore;
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        ScoreText.text="Score: "+(long)player.score;
        HighScoreText.text = "High Score: " + highScore;
        if (highScore < player.score)
        {
            highScore = (long)player.score;
        }
	}

    void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", (int)highScore);
    }
}
