using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static List<EnnemyMovement> enemyList = new List<EnnemyMovement>();

    public static EnnemyMovement GetClosestEnemy(Vector3 position, float maxRange)
    {
        EnnemyMovement closest = null;
        foreach (var enemy in enemyList)
        {
            if(enemy != null)
            {
                if (Vector3.Distance(position, enemy.transform.position) <= maxRange)
                {
                    if (closest == null)
                    {
                        closest = enemy;
                    }
                    else
                    {
                        if (Vector3.Distance(position, enemy.transform.position) < Vector3.Distance(position, closest.transform.position))
                        {
                            closest = enemy;
                        }
                    }
                }

            }
        }
        return closest;
    }
}
