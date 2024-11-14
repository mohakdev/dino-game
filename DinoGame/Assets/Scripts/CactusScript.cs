using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusScript : MonoBehaviour
{
    [SerializeField] AudioClip dieSound;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HighscoreScript>().UpdateHighScore();
            collision.gameObject.GetComponent<Animator>().SetTrigger("dead");
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>().PlayOneShot(dieSound);
            GameObject.FindGameObjectWithTag("GameOver").transform.localScale = Vector3.one;
            Time.timeScale = 0;
            GameController.started = false;
        }
    }
}
