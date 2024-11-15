using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DayNightScript;

public class HighscoreScript : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;

    int highscore;
    public float score;
    public int checkpoint = 700;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("hs", 0);
        if(highscore != 0) { highScoreText.text = "HI  " + highscore.ToString("00000"); }
    }

    void Update()
    {
        if(!GameController.started || GameController.paused || GameController.gameOver) { return; }
        score += Time.deltaTime * 10;
        scoreText.text = ((int)score).ToString("00000");

        HandleDayNightLogic();
    }

    public void UpdateHighScore()
    {
        if(score > highscore)
        {
            PlayerPrefs.SetInt("hs", (int)score);
        }
    }

    public void HandleDayNightLogic()
    {
        if (score >= checkpoint)
        {
            print("running");
            ToggleTheme();
            if(checkpoint % 700 == 0) { checkpoint += 200; return; }
            checkpoint += 500;
        }
    }
}
