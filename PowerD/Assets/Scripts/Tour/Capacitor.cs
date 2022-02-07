using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacitor : MonoBehaviour
{
    public TowerManager towerManager;

    public bool isInTowerSocket;

    public GameHandler _GameHandler;

    public bool shouldPower;
    public TowerSocket previousTowerSocket;

    // Start is called before the first frame update
    void Start()
    {
        shouldPower = true;
        isInTowerSocket = false;
        towerManager = GetComponent<TowerManager>();
        _GameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }


    // Update is called once per frame
    void Update()
    {
        if(towerManager.towerSocket && shouldPower)
        {
            towerManager.towerSocket.powerLevel += 1;
            shouldPower = false;
            previousTowerSocket = towerManager.towerSocket;
        }

        if (!towerManager.towerSocket && shouldPower == false)
        {
            if(previousTowerSocket && previousTowerSocket.powerLevel > 0)
                previousTowerSocket.powerLevel -= 1;

            shouldPower = true;
        }
    }
}
