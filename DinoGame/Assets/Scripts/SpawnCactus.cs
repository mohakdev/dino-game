using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnCactus : MonoBehaviour
{
    [SerializeField] Sprite[] cactuses;
    [SerializeField] GameObject cactusPrefab;
    [SerializeField] float delayTime = 1f;

    void Start()
    {
        InvokeRepeating(nameof(MakeNewCactus), delayTime, delayTime);
    }
    void MakeNewCactus()
    {
        if (!GameController.started) { return; }
        GameObject cactus = Instantiate(cactusPrefab,transform.position,Quaternion.identity);
        cactus.GetComponent<SpriteRenderer>().sprite = SelectRandomCactus();
        cactus.transform.SetParent(GroundManager.currentGround.transform, true);
    }

    Sprite SelectRandomCactus()
    {
        int random = Random.Range(0, cactuses.Length);
        return cactuses[random];
    }
}
