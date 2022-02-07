using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorLamp : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderers;
    public Sprite[] sprites;
    public TowerSocket towerSocket;
    
    // Update is called once per frame
    void Update()
    {
        switch (towerSocket.powerLevel)
        {
            case 0:
                spriteRenderers[0].sprite = sprites[0];
                spriteRenderers[1].sprite = sprites[0];
                break;
            case 1:
                spriteRenderers[0].sprite = sprites[1];
                spriteRenderers[1].sprite = sprites[0];
                break;
            case 2:
                spriteRenderers[0].sprite = sprites[1]; 
                spriteRenderers[1].sprite = sprites[1];
                break;
            default:
                break;
        }
    }
}
