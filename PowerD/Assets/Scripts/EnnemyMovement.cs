using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{

    public float speed;

    private Transform target;
    private int waypointIndex = 0;
    public Waypoints waypoints;

    public GameHandler _GameHandler;


    private void Awake()
    {
        Enemy.enemyList.Add(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        target = waypoints.points[waypointIndex];
        _GameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waypoints == null)
        {
            Destroy(gameObject);
        }
        if(target != null)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }
    }

    private void GetNextWaypoint()
    {

        if (waypointIndex >= waypoints.points.Length - 1)
        {

            if (TryGetComponent<Ennemy_1>(out Ennemy_1 component))
            {
                _GameHandler.DamageCore(component.powerAdd * component.health);
            } else
            {
                _GameHandler.ShutDownCable();
            }

            //SoundManager.PlaySound(SoundManager.Sound.EnnemyHit);
            Destroy(gameObject);

            return;
        }

        waypointIndex++;

        target = waypoints.points[waypointIndex];

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 9)
        {
            other.gameObject.GetComponent<Cable>().DisableCable();
        }
    }
}
