using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonIcon : MonoBehaviour
{
    [SerializeField] RawImage pauseImg;
    [SerializeField] RawImage soundImg;
    [SerializeField] RawImage themeImg;

    [SerializeField] Texture pauseTex;
    [SerializeField] Texture resumeTex;

    [SerializeField] Texture dayTex;
    [SerializeField] Texture nightTex;

    [SerializeField] Texture soundOnTex;
    [SerializeField] Texture soundOffTex;

    [SerializeField] AudioSource audioSource;

    public void ChangePauseIcon()
    {
        if (GameController.paused) { pauseImg.texture = resumeTex; }
        else { pauseImg.texture = pauseTex; }
        Invoke(nameof(PauseIcon), 0.2f);
    }

    public void ChangeSoundIcon()
    {
        if(audioSource.volume == 1f) { soundImg.texture = soundOffTex; }
        else { soundImg.texture = soundOnTex; }
    }

    public void ChangeThemeIcon()
    {
        if (DayNightScript.currentTheme == DayNightScript.DayNightTheme.Day) { themeImg.texture = nightTex; }
        else { themeImg.texture = dayTex; }
    }
    void PauseIcon()
    {
        if (GameController.paused) { pauseImg.texture = resumeTex; }
        else { pauseImg.texture = pauseTex; }
    }

}
