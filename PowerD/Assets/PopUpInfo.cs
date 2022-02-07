using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpInfo : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public GameObject raycastBlocker;
    public GameObject infoPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Time.timeScale = 0;
        spriteRenderer.sprite = sprites[0];
        spriteRenderer.color = Color.HSVToRGB(0, 0, 0.9f);

        //enable correct info
        raycastBlocker.SetActive(true);
        infoPanel.SetActive(true);
    }

    private void OnMouseEnter()
    {
        spriteRenderer.sprite = sprites[1];
        spriteRenderer.color = Color.HSVToRGB(0, 0, 1f);
    }

    private void OnMouseExit()
    {
        spriteRenderer.sprite = sprites[0];
        spriteRenderer.color = Color.HSVToRGB(0, 0, 0.9f);

    }
}
