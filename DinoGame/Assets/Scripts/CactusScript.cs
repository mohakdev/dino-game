using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<HighscoreScript>().UpdateHighScore();
            GameObject.FindGameObjectWithTag("GameOver").transform.localScale = Vector3.one;
            Time.timeScale = 0;
            GameController.started = false;
        }
    }
}
