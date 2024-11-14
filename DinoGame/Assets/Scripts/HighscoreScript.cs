using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreScript : MonoBehaviour
{
    public float score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.started) { return; }
        score += Time.deltaTime * 10;
    }
}
