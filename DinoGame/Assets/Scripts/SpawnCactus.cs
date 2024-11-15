using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnCactus : MonoBehaviour
{
    [SerializeField] GameObject[] cactuses;

    void Start()
    {
        StartCoroutine(MakeNewObstacle());
    }
    void MakeNewCactus()
    {
        if (!GameController.started || GameController.paused || GameController.gameOver) { return; }
        GameObject cactus = Instantiate(SelectRandomCactus(), transform.position, Quaternion.identity);
        cactus.transform.SetParent(GroundManager.currentGround.transform, true);
    }

    IEnumerator MakeNewObstacle()
    {
        float delayTime = 2f;
        while (true)
        {
            MakeNewCactus();
            if(GroundManager.speed != 0) { delayTime = 4 / GroundManager.speed; }
            delayTime = Random.Range(delayTime - 0.2f, delayTime + 0.2f);
            yield return new WaitForSeconds(delayTime);
        }
    }

    GameObject SelectRandomCactus()
    {
        int random = Random.Range(0, cactuses.Length);
        return cactuses[random];
    }
}
