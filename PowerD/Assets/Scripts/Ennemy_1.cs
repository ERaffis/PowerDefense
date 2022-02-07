using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_1 : MonoBehaviour
{
    //Adds power

    public float powerAdd;
    private GameHandler _GameHandler;
    [Range(0, 8)]
    public int health;
    public SpriteRenderer sprite;
    public float colorValue;
    public EnnemyMovement ennemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        colorValue = 1;
        _GameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        sprite = GetComponent<SpriteRenderer>();
        ennemyMovement = GetComponent<EnnemyMovement>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        //DamageEnnemy();
    }

    public void DamageEnnemy()
    {
        health--;
        colorValue -= 0.2f;
        transform.localScale *= 0.85f;
        sprite.color = Color.HSVToRGB(0,0,colorValue);
        if (health == 0)
        {
            //_GameHandler.DamageCore(powerAdd);
            Enemy.enemyList.Remove(GetComponent<EnnemyMovement>());
            Destroy(gameObject);
            return;
        }


    }
}
