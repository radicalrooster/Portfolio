using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{

    public Sprite[] sprites;
    public int currentSprite = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (currentSprite == -1)
        {
            currentSprite = Random.Range(0, sprites.Length);
        } else if (currentSprite > sprites.Length)
        {
            currentSprite = sprites.Length - 1;
        }

        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
