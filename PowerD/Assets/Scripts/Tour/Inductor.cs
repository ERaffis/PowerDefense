using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inductor : MonoBehaviour
{
    //Trouve tous les ennemis dans un cercle et applique un degats sur chaque a un certain intervalle de temps

    private TowerManager towerManager;
    public float range;
    public int tickForShoot;
    public GameObject animationObject;
    public GameObject rangeView1, rangeView2;

    // Start is called before the first frame update
    void Start()
    {
        towerManager = GetComponent<TowerManager>();
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;

        rangeView1 = transform.Find("Range_1").gameObject;
        rangeView2 = transform.Find("Range_2").gameObject;

    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (towerManager.towerSocket)
        {
            if(e.tick > 5)
            {
                if (towerManager.powerLevel != 0)
                {
                    if (e.tick % (tickForShoot / towerManager.powerLevel) == 0)
                        TowerAttack();
                } else
                {
                    if (e.tick % (tickForShoot ) == 0)
                        TowerAttack();
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(towerManager.towerSocket != null)
        {
            if (towerManager.powerLevel > 0)
            {
                animationObject.SetActive(true);
                animationObject.GetComponent<Animator>().SetFloat("AnimationSpeed", 1);
                if (towerManager.powerLevel > 1)
                {
                    animationObject.GetComponent<Animator>().SetFloat("AnimationSpeed", 2);
                }
            }
            else
            {
                animationObject.SetActive(false);
            }
        } else
        {
            animationObject.SetActive(false);
        }
    }

    void TowerAttack()
    {
        switch (towerManager.powerLevel)
        {
            case 0:
                break;
            case 1:
                Collider2D[] ennemies =  Physics2D.OverlapCircleAll(transform.position, range, LayerMask.GetMask("Ennemies"));
                foreach (var ennemy in ennemies)
                {
                    Debug.Log(ennemy.gameObject.name);
                    if(ennemy.TryGetComponent<Ennemy_1>(out Ennemy_1 ennemy_1))
                    {
                        ennemy_1.DamageEnnemy();
                    } else
                    {
                        ennemy.GetComponent<Ennemy_2>().DamageEnnemy();
                    }
                }
                break;
            case 2:
                Collider2D[] ennemies1 = Physics2D.OverlapCircleAll(transform.position, range, LayerMask.GetMask("Ennemies"));
                foreach (var ennemy in ennemies1)
                {
                    if (ennemy.TryGetComponent<Ennemy_1>(out Ennemy_1 ennemy_1))
                    {
                        ennemy_1.DamageEnnemy();
                    }
                    else
                    {
                        ennemy.GetComponent<Ennemy_2>().DamageEnnemy();
                    }
                }
                break;
            case 3:
                Debug.Log("Attack Power 3");
                break;
            default:
                break;
        }
    }

    private void OnMouseEnter()
    {
        switch (towerManager.powerLevel)
        {
            case 0:
                break;
            case 1:
                rangeView1.GetComponent<SpriteRenderer>().enabled = true;
                break;
            case 2:
                rangeView2.GetComponent<SpriteRenderer>().enabled = true;
                break;

            default:
                break;
        }
    }

    private void OnMouseDown()
    {
        rangeView1.GetComponent<SpriteRenderer>().enabled = false;
        rangeView2.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnMouseExit()
    {
        rangeView1.GetComponent<SpriteRenderer>().enabled = false;
        rangeView2.GetComponent<SpriteRenderer>().enabled = false;
    }
}
