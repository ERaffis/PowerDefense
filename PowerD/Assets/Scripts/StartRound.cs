using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRound : MonoBehaviour
{
    public GameObject[] ennemySpwaners;
    public GameHandler _GameHandler;

    private Button startRoundButton;

    // Start is called before the first frame update
    void Start()
    {
        _GameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        startRoundButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_GameHandler.isInRound)
        {
            startRoundButton.interactable = false;
        } else
        {
            startRoundButton.interactable = true;
        }
    }


    public void StartNewRound()
    {
        _GameHandler.isInRound = true;
        foreach (GameObject ennemySpawner in ennemySpwaners)
        {
            GameObject.Find("TimeTickSystem").GetComponent<TimeTickSystem>().shouldTick = true;
        }
    }
}
