using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField] int jumpPower;
    bool onGround = true;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.tapCount == 1) { Jump(); } 
        }
        else if (Input.GetKeyDown(KeyCode.Space)) { Jump(); }
    }

    void Jump()
    {
        if(!onGround) { return; }
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        onGround = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundCollider"))
        {
            onGround = true;
        }    
    }
}
