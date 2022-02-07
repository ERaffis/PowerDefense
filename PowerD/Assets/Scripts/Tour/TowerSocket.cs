using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSocket : MonoBehaviour
{
    public bool hasTower;
    public GameObject tower;
    public SpriteRenderer sprite;

    public int powerLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerLevel < 0)
            powerLevel = 0;

      
        switch (powerLevel)
        {
            case 0:
                sprite.color = Color.HSVToRGB(0.15f,0.6f,0.5f);
                break;

            case 1:
                sprite.color = Color.HSVToRGB(0.15f, 0.6f, 0.7f);
                break;

            case 2:
                sprite.color = Color.HSVToRGB(0.15f, 0.6f, 0.9f);
                break;

            default:
                break;
        }
    }
}
