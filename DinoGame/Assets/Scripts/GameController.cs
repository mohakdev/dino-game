using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject introBar;
    public static bool started = false;

    // Update is called once per frame
    void Update()
    {
        if(!started) 
        { 
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                print("Started");
                //Intro bar slide
                LeanTween.moveX(introBar,4.3f, 0.5f).setEaseInQuad().setOnComplete(() => {
                    Destroy(introBar);
                });
                //Start Player Anim
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Animator>().SetTrigger("startRun");
                started = true; 
            } 
        }
    }
}
