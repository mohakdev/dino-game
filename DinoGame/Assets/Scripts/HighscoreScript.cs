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
    bool themeChangedRecently = false;

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
        if(score >= 700 && !themeChangedRecently)
        {
            ChangeTheme(false);
        }
        else if(score >= 1400 && !themeChangedRecently)
        {
            ChangeTheme(true);
        }
    }
    public void ChangeTheme(bool nightMode)
    {
        float startVal = 0f;
        float endVal = 1f;
        if(nightMode) { startVal = 1f; endVal = 0f; }
        themeChangedRecently = true;
        LeanTween.value(gameObject, startVal, endVal, 1f).setOnUpdate((float thresholdValue) =>
        {
            mat.SetFloat("_Threshold", thresholdValue);
        });
        Invoke(nameof(ResetThemeChangeBool), 10f);
    }
    void ResetThemeChangeBool()
    {
        themeChangedRecently = false;
    }

    public void UpdateHighScore()
    {
        if(score > highscore)
        {
            PlayerPrefs.SetInt("hs", (int)score);
        }
    }
}
