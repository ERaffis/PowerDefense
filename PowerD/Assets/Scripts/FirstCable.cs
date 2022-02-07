using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCable : MonoBehaviour
{
    public bool isActive = false;
    public SpriteRenderer sprite;
    public GameObject[] endConnection;


    private GameHandler _GameHandler;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        _GameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        ChangeCableState();
    }

    public void ChangeCableState()
    {

        if (isActive == true)
        {
            isActive = false;

            sprite.color = Color.HSVToRGB(0.15f, 0.9f, 0.75f);
            _GameHandler.powerCable.fillAmount += 0.1f;


            foreach (var item in endConnection)
            {
                item.GetComponent<TowerSocket>().powerLevel--;
            }

        }
        else
        {
            isActive = true;
            sprite.color = Color.HSVToRGB(0.15f, 0.9f, 1);

            _GameHandler.powerCable.fillAmount -= 0.1f;

            foreach (var item in endConnection)
            {
                item.GetComponent<TowerSocket>().powerLevel++;
            }
        }

    }
}
