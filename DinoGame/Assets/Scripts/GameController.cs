using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject introBar;
    [SerializeField] Text pauseCountText;

    public static bool firstTime = true;
    public static bool started = false;
    public static bool paused = false;
    public static bool gameOver = false;

    void Start()
    {
        if (!firstTime)
        {
            started = true;
            Destroy(introBar);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Animator>().SetTrigger("startRun");
        }    
    }

    public void TogglePause()
    {
        if (!started || gameOver) { return; }
        if (!paused) { PauseGame(); }
        else { ResumeGame(); }
    }

    public void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown()
    {
        int count = 3;
        pauseCountText.gameObject.SetActive(true);
        while(count > 0)
        {
            pauseCountText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }
        pauseCountText.gameObject.SetActive(false);
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
            if (Input.GetMouseButtonDown(0) && !JumpScript.IsPointerOverUIObject()) 
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
                firstTime = false;
            } 
        }
    }
}
