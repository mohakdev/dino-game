using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField] float maxSpeed = 7f;
    [SerializeField] float startSpeed = 2f;
    public static float speed;
    [SerializeField] GameObject groundPrefab;
    [SerializeField] Vector2 triggerNewGroundPos;
    [SerializeField] Vector2 spawnPos;

    public static PlatformMovement currentGround;
    void Start()
    {
        currentGround = GameObject.Find("Ground").GetComponent<PlatformMovement>();
        speed = startSpeed;
    }
    void Update()
    {
        if(speed <= maxSpeed) { speed += 0.05f * Time.deltaTime; }
        //Spawn new grounds
        if (currentGround.transform.position.x < triggerNewGroundPos.x && !currentGround.hasSpawnedNewGround)
        {
            currentGround.hasSpawnedNewGround = true;
            GameObject newGround = Instantiate(groundPrefab);
            newGround.name = "NewGround";
            newGround.transform.position = spawnPos;
            currentGround = newGround.GetComponent<PlatformMovement>();
        }
    }

    
}
