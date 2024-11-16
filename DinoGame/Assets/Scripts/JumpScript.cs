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
        if(Input.GetMouseButtonDown(0) && !IsPointerOverUIObject()) { Jump(); }
    }

    public static bool IsPointerOverUIObject()
    {
        // Check if there are any touches
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = touch.position
            };

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);

            return results.Count > 0; // True if the pointer is over a UI element
        }

        // For desktop testing
        return EventSystem.current.IsPointerOverGameObject();
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
