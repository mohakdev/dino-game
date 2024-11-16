using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightScript : MonoBehaviour
{
    static Text gameTitle;
    static GameObject go;
    static Material material;
    public static DayNightTheme currentTheme;
    void Start()
    {
        material = gameObject.GetComponent<SpriteRenderer>().sharedMaterial;
        material.SetFloat("_Threshold", 0f);
        gameTitle = GameObject.FindGameObjectWithTag("GameTitle").GetComponent<Text>();
        go = gameObject; //for leantween transition
        currentTheme = DayNightTheme.Day;
    }
    public enum DayNightTheme
    {
        Day,
        Night
    }
    
    public static void ChangeDayNightTheme(DayNightTheme theme)
    {
        //Default conditions for Night
        float startVal = 0f;
        float endVal = 1f;
        if (theme == DayNightTheme.Day) { startVal = 1f; endVal = 0f; }
        currentTheme = theme;
        LeanTween.value(go, startVal, endVal, 1f).setIgnoreTimeScale(true).setOnUpdate((float thresholdValue) =>
        {
            material.SetFloat("_Threshold", thresholdValue);
        });
        LeanTween.value(gameTitle.gameObject,Mathf.Clamp(startVal,0.32f,0.67f), Mathf.Clamp(endVal, 0.32f, 0.67f), 1f).setIgnoreTimeScale(true).setOnUpdate((float val) =>
        {
            gameTitle.color = new Color(val, val, val, 1);
        });
        print("theme successfully changed to " + currentTheme);
    }

    public void ToggleThemeFromMenu()
    {
        if (!GameController.started)
        {
            ToggleTheme();
        }
        else if (GameController.started && GameController.gameOver)
        {
            ToggleTheme();
        }
    }

    public static void ToggleTheme()
    {
        if(currentTheme == DayNightTheme.Night)
        {
            ChangeDayNightTheme(DayNightTheme.Day);
            return;
        }
        ChangeDayNightTheme(DayNightTheme.Night);
    }
}
