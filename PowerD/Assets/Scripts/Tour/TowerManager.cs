using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public TowerSocket towerSocket;
    public int powerLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        towerSocket = GetComponent<DragTowers>().towerSocket;

        if(towerSocket)
        {
            powerLevel = towerSocket.powerLevel;
        }
    }
}
