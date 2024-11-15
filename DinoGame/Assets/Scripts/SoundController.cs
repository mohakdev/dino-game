using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    bool soundOn = true;
    public void ToggleSound()
    {
        soundOn = !soundOn;
        if(soundOn) { audioSource.volume = 1f; }
        else { audioSource.volume = 0; }
    }
}
