using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaShow : MonoBehaviour
{
    public GameObject rangeView1, rangeView2;

    // Start is called before the first frame update
    void Start()
    {
        rangeView1 = transform.Find("Range_1").gameObject;
        rangeView2 = transform.Find("Range_2").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        switch (GetComponent<TowerManager>().powerLevel)
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
