using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float deletePos;

    public bool hasSpawnedNewGround = false;
    void Update()
    {
        if(!GameController.started) { return; }
        transform.position += speed * Time.deltaTime * Vector3.left;
        //Condition to delete gameobject
        if (transform.position.x < deletePos)
        {
            Destroy(gameObject);
        }
    }
}
