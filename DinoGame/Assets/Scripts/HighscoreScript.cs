using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreScript : MonoBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;

    int highscore;
    public float score;
    public int checkpoint = 700;

    void Start()
    {
        mat.SetFloat("_Threshold", 0f);
        highscore = PlayerPrefs.GetInt("hs", 0);
        if(highscore != 0) { highScoreText.text = "HI  " + highscore.ToString("00000"); }
    }

    void Update()
    {
        if(!GameController.started) { return; }
        score += Time.deltaTime * 10;
        scoreText.text = ((int)score).ToString("00000");

        if(score >= checkpoint)
        {
            if(checkpoint % 1400 == 0)
            {
                ChangeThemeToDay();
            }
            else { ChangeThemeToNight(); }
            checkpoint += 700;
        }
    }
    public void ChangeThemeToNight()
    {
        float startVal = 0f;
        float endVal = 1f;
        LeanTween.value(gameObject, startVal, endVal, 1f).setOnUpdate((float thresholdValue) =>
        {
            mat.SetFloat("_Threshold", thresholdValue);
        });
    }
    public void ChangeThemeToDay()
    {
        float startVal = 1f;
        float endVal = 0f;
        LeanTween.value(gameObject, startVal, endVal, 1f).setOnUpdate((float thresholdValue) =>
        {
            mat.SetFloat("_Threshold", thresholdValue);
        });
    }

    public void UpdateHighScore()
    {
        if(score > highscore)
        {
            PlayerPrefs.SetInt("hs", (int)score);
        }
    }
}
