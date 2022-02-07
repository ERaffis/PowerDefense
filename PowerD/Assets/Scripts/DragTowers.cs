using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTowers : MonoBehaviour
{
    public Vector3 initialPosition;
    private Vector3 screenPoint;
    private Vector3 offset;

    private Vector3 startPosition;
    public TowerSocket towerSocket;
    public TowerSocket previousTowerSocket;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }
    
    private void OnMouseDown()
    {
        startPosition = transform.position;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        if(towerSocket)
        {
            previousTowerSocket = towerSocket;
            towerSocket.hasTower = false;
            towerSocket = null;
        }
    }

    private void OnMouseDrag()
    {

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    private void OnMouseUp()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, 1, LayerMask.GetMask("TowerSocket"));
        if (col && !col.gameObject.GetComponent<TowerSocket>().hasTower)
        {
            transform.position =  new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, -0.095f);
            towerSocket = col.gameObject.GetComponent<TowerSocket>();
            towerSocket.hasTower = true;
            
        } else
        {
            if(previousTowerSocket)
            {
                towerSocket = previousTowerSocket;
                towerSocket.hasTower = true;
            }
            transform.position = startPosition;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.position = initialPosition;
            if (towerSocket)
            {
                towerSocket.hasTower = false;
                towerSocket = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
