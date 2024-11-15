using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject introBar;
    public static bool started = false;
    public static bool paused = false;
    public static bool gameOver = false;

    public static void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
    }
    public static void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1;
    }
    public static void EndGame()
    {
        gameOver = true;
        Time.timeScale = 0;
    }
    public static void RestartGame()
    {
        started = false;
        gameOver = false;
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        
    }

    void Update()
    {
        if(!started) 
        { 
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            {
                print("Started");
                //Intro bar slide
                if(introBar)
                {
                    LeanTween.moveX(introBar,4.3f, 0.5f).setEaseInQuad().setOnComplete(() => {
                        Destroy(introBar);
                    });
                }
                //Start Player Anim
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Animator>().SetTrigger("startRun");
                started = true; 
            } 
        }
    }
}
