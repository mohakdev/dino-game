using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DayNightScript : MonoBehaviour
{
    static GameObject go;
    static Material material;
    public static DayNightTheme playerSelectedTheme { get; private set; }
    void Start()
    {
        material = gameObject.GetComponent<SpriteRenderer>().sharedMaterial;
        material.SetFloat("_Threshold", 0f);
        go = gameObject; //for leantween transition
        playerSelectedTheme = DayNightTheme.Day;
        
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

        LeanTween.value(go, startVal, endVal, 1f).setOnUpdate((float thresholdValue) =>
        {
            material.SetFloat("_Threshold", thresholdValue);
        });
    }
}
