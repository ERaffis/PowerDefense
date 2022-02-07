using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public GameObject[] ennemies;

    public int timeBetweenSpawn;
    public bool shouldSpawn;
    public int waitUntilTickToSpawn;

    public Waypoints waypoints;
    private Vector3 spawnPosition;

    public SpriteRenderer pathwaySprite;

    private void Start()
    {
        spawnPosition = transform.position;
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }
    private void Update()
    {
        if (shouldSpawn == false)
        {
            pathwaySprite.color = Color.gray;
        } else
        {
            pathwaySprite.color = Color.white;
        }
    }

    public void StartRound()
    {
        shouldSpawn = true;
    }

    private void InstantiateEnnemy()
    {
        if (Random.Range(0f, 1f) >= 0.2f)
        {
            GameObject ennemy = Instantiate(ennemies[0], spawnPosition, Quaternion.identity);
            ennemy.GetComponent<EnnemyMovement>().waypoints = waypoints;
            return;
        }
        else
        {
            GameObject ennemy = Instantiate(ennemies[1], spawnPosition, Quaternion.identity);
            ennemy.GetComponent<EnnemyMovement>().waypoints = waypoints;
            return;

        }
    }

    private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (e.tick >= waitUntilTickToSpawn)
            shouldSpawn = true;

        if(shouldSpawn)
        {
            if (e.tick % timeBetweenSpawn /* / e.tick*/ == 0)
            {
                InstantiateEnnemy();
            }
        }
    }
}
