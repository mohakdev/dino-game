using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    bool hasSpawnedNewGround = false;
    [SerializeField] float speed;
    [SerializeField] Vector2 spawnPos;

    // Update is called once per frame
    void Update()
    {
        if(!GameController.started) { return; }
        transform.position += speed * Time.deltaTime * Vector3.left;
        if(transform.position.x < -11.5f && !hasSpawnedNewGround)
        {
            hasSpawnedNewGround = true;
            GameObject newGround = Instantiate(gameObject);
            newGround.name = "NewGround";
            newGround.transform.position = spawnPos;
            Invoke(nameof(SelfDestruct), 5f);
        }
    }
    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
