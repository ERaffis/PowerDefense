using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    [Range(0,5)]
    public int health;
    public Sprite[] sprites;
    public int currentSprite = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        DamageEnnemy();
    }

    public void DamageEnnemy()
    {
        health--;
        currentSprite++;

        if(health == 0)
        {
            Destroy(gameObject);
            return;
        }

        
        GetComponent<SpriteRenderer>().sprite = sprites[currentSprite];
    }    
}
