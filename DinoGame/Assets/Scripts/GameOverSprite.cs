using UnityEngine;
using UnityEngine.UI;

public class GameOverSprite : MonoBehaviour
{
    Image render;
    [SerializeField] Sprite daySprite;
    [SerializeField] Sprite nightSprite;
    HighscoreScript hsScript;

    void Start()
    {
        render = GetComponent<Image>();
        hsScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HighscoreScript>();
    }

    void Update()
    {
        if (hsScript.checkpoint % 1400 == 0)
        {
            render.sprite = nightSprite;
        }
        else
        {
            render.sprite = daySprite;
        }
    }

}
