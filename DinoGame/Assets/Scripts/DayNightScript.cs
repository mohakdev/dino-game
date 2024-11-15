using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{
    static GameObject go;
    static Material material;
    static DayNightTheme currentTheme;
    void Start()
    {
        material = gameObject.GetComponent<SpriteRenderer>().sharedMaterial;
        material.SetFloat("_Threshold", 0f);
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
        print("theme to transition to " +theme);
        float startVal = 0f;
        float endVal = 1f;
        if (theme == DayNightTheme.Day) { startVal = 1f; endVal = 0f; }
        currentTheme = theme;


        LeanTween.value(go, startVal, endVal, 1f).setOnUpdate((float thresholdValue) =>
        {
            material.SetFloat("_Threshold", thresholdValue);
        });
    }

    public void ToggleThemeFromMenu()
    {
        if (GameController.started) { return; }
        ToggleTheme();
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
