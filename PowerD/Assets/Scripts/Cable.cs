using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public bool isActive = false;
    public SpriteRenderer sprite;

    public GameObject startConnection;
    public GameObject[] endConnection;

    [SerializeField]
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

        if(startConnection)
        {
            if (!startConnection.GetComponent<TowerSocket>().hasTower && isActive)
            {
                DisableCable();
            }
            if (startConnection.GetComponent<TowerSocket>().powerLevel == 0 && isActive)
            {
                DisableCable();
            }

        }
    }

    private void OnMouseDown()
    {
        ChangeCableState();
    }

    public void ChangeCableState()
    {
        if(startConnection)
        {
            if (startConnection.GetComponent<TowerSocket>().hasTower && startConnection.GetComponent<TowerSocket>().powerLevel > 0)
            {
                if (isActive == true)
                {
                    isActive = false;

                    sprite.color = Color.HSVToRGB(0.15f, 0.6f, 0.6f);
                    _GameHandler.powerCable.fillAmount -= 0.1f;


                    foreach (var item in endConnection)
                    {
                        item.GetComponent<TowerSocket>().powerLevel--;
                    }
                    return;
                }
                else
                {
                    isActive = true;
                    sprite.color = Color.HSVToRGB(0.15f, 0.6f, 1);

                    _GameHandler.powerCable.fillAmount += 0.1f;

                    foreach (var item in endConnection)
                    {
                        item.GetComponent<TowerSocket>().powerLevel++;
                    }
                    //SoundManager.PlaySound(SoundManager.Sound.Cable);
                    return;
                }
            }
        }
    }

    public void DisableCable()
    {
        isActive = false;
        
        sprite.color = Color.HSVToRGB(0.15f, 0.6f, 0.6f);

        _GameHandler.powerCable.fillAmount -= 0.1f;

        foreach (var item in endConnection)
        {
            item.GetComponent<TowerSocket>().powerLevel--;
        }
    }
}
