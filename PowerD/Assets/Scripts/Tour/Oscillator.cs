using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Oscillator : MonoBehaviour
{
    private TowerManager towerManager;
    public float range;
    public int tickForShoot;

    private Vector3 shootPosition;
    public GameObject projectile;
    private Transform target;

    public GameObject effect;

    public GameObject rangeView1, rangeView2;

    private void Awake()
    {
        towerManager = GetComponent<TowerManager>();
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }
    // Start is called before the first frame update
    void Start()
    {
        rangeView1 = transform.Find("Range_1").gameObject;
        rangeView2 = transform.Find("Range_2").gameObject;
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (towerManager.towerSocket)
        {
            if(e.tick % tickForShoot == 0)
                TowerAttack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
            Debug.Log(target.gameObject.name);

        switch (towerManager.powerLevel)
        {
            case 0: range = 0;
                effect.SetActive(false);
                break;
            case 1: range = 4f;
                effect.SetActive(true);
                break;
            case 2: range = 6f;
                effect.SetActive(true);
                break;

            default:
                break;
        }
    }

    void TowerAttack()
    {
        switch (towerManager.powerLevel)
        {
            case 0:
                break;
            case 1:
                EnnemyMovement ennemyPosition = GetClosestEnnemy(range);
                if (ennemyPosition != null)
                {
                    shootPosition = transform.Find("ProjectileShootLocation").position;
                    ProjectileOscillator.Create(projectile, shootPosition, ennemyPosition);
                }
                break;
            case 2:

                EnnemyMovement ennemyPosition2 = GetClosestEnnemy(range);
                if (ennemyPosition2 != null)
                {
                    shootPosition = transform.Find("ProjectileShootLocation").position;
                    ProjectileOscillator.Create(projectile, shootPosition, ennemyPosition2);
                }
                break;
            default:
                break;
        }
    }

    EnnemyMovement GetClosestEnnemy(float range)
    {
        EnnemyMovement ennemy =  Enemy.GetClosestEnemy(transform.position, range);
        if(ennemy)
        {
            Debug.Log(ennemy.gameObject.name);
            return ennemy;
        }

        return null;
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
