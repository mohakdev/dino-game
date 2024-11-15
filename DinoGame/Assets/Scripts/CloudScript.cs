using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    [SerializeField] float startPos;
    [SerializeField] float endPos;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < endPos)
        {
            transform.position = new Vector2(startPos,transform.position.y);
        }
    }
}
