using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnCactus : MonoBehaviour
{
    [SerializeField] GameObject[] cactuses;
    [SerializeField] float delayTime = 1f;

    void Start()
    {
        InvokeRepeating(nameof(MakeNewCactus), delayTime, delayTime);
    }
    void MakeNewCactus()
    {
        if (!GameController.started) { return; }
        GameObject cactus = Instantiate(SelectRandomCactus(), transform.position,Quaternion.identity);
        if(cactus.name == "Cactus 9(Clone)" || cactus.name == "Cactus 10(Clone)" || cactus.name == "Cactus 11(Clone)")
        {
            cactus.transform.position += Vector3.up * 0.1f;
        }
        cactus.transform.SetParent(GroundManager.currentGround.transform, true);
    }

    GameObject SelectRandomCactus()
    {
        int random = Random.Range(0, cactuses.Length);
        return cactuses[random];
    }
}
