using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_2 : MonoBehaviour
{
    //Removes power

    public float powerSubstract;
    private GameHandler _GameHandler;
    [Range(0, 3)]
    public int health;
    public SpriteRenderer sprite;
    public float colorValue;
    public EnnemyMovement ennemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        colorValue = 1;
        _GameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        sprite = GetComponent<SpriteRenderer>();
        ennemyMovement = GetComponent<EnnemyMovement>();
        ennemyMovement.speed *= 2;

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
        sprite.color = Color.HSVToRGB(0, 0, colorValue);
        if (health == 0)
        {
            Enemy.enemyList.Remove(GetComponent<EnnemyMovement>());
            Destroy(gameObject);
            return;
        }


    }

}
