using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpScript : MonoBehaviour
{
    [SerializeField] int jumpPower;
    [SerializeField] AudioClip jumpSound;
    bool onGround = true;
    Rigidbody2D rb;
    Animator animator;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) { Jump(); }
    }

    void Jump()
    {
        if(!onGround) { return; }
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        audioSource.PlayOneShot(jumpSound);
        onGround = false;
        animator.SetTrigger("idle");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundCollider"))
        {
            onGround = true;
            //Animation Logic
            if(GameController.started) { animator.SetTrigger("startRun"); }
        }
    }
}
