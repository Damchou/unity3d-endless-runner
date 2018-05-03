using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    private int highscore;
    private int score;
    Text text;

    // Set highscoreText up in the inspector
    public Text highscoreText;

	// Use this for initialization
	void Awake ()
    {
        text = GetComponent<Text>();
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.GetInt("highscore", highscore);
            highscoreText.text = "Best: " + highscore;
        }
        text.text = "Score: " + score;
	}

    public void Scoring()
    {
        score++;
    }

    public void resetScore()
    {
        score = 0;
    }
}
