using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] bool isCloud;
    [SerializeField] float deletePos;

    public bool hasSpawnedNewGround = false;
    void Update()
    {
        if(!GameController.started || GameController.paused || GameController.gameOver) { return; }
        float speed = GroundManager.speed;
        if (isCloud) { speed = GroundManager.speed / 2f; }
      
        transform.position += speed * Time.deltaTime * Vector3.left;
        //Condition to delete gameobject
        if (transform.position.x < deletePos)
        {
            Destroy(gameObject);
        }
    }
}
