using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistor : MonoBehaviour
{
    private TowerManager towerManager;
    public float range;
    public float slowPower;
    public CircleCollider2D circleCollider;



    // Start is called before the first frame update
    void Start()
    {
        towerManager = transform.parent.GetComponent<TowerManager>();
        circleCollider = GetComponent<CircleCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        circleCollider.radius = range;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            if(towerManager.powerLevel != 0)
            {
                other.GetComponent<EnnemyMovement>().speed *= slowPower * (2 / towerManager.powerLevel);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            if (towerManager.powerLevel != 0)
            {
                other.GetComponent<EnnemyMovement>().speed /= slowPower * (2 / towerManager.powerLevel);
            }
        }

    }

}
