using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField] GameObject groundPrefab;
    [SerializeField] Vector2 triggerNewGroundPos;
    [SerializeField] Vector2 spawnPos;

    public static PlatformMovement currentGround;
    void Start()
    {
        currentGround = GameObject.Find("Ground").GetComponent<PlatformMovement>();    
    }
    void Update()
    {
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
