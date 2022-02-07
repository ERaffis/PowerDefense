using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ProjectileOscillator : MonoBehaviour
{
    public float moveSpeed;

    public static void Create(GameObject projectile, Vector3 spawnPosition, EnnemyMovement ennemy)
    {
        GameObject projectileObject = Instantiate(projectile, spawnPosition, Quaternion.identity);

        ProjectileOscillator projectileOscillator =  projectileObject.GetComponent<ProjectileOscillator>();
        projectileOscillator.Setup(ennemy);
    }

    private EnnemyMovement ennemy;
    private void Setup(EnnemyMovement ennemy)
    {
        this.ennemy = ennemy;
    }

    private void Update()
    {
        Destroy(this.gameObject, 5f);
        if(ennemy != null)
        {
            Vector3 targetPosition = ennemy.transform.position;
            Vector3 moveDir = (targetPosition - transform.position).normalized;

            transform.position += moveDir * moveSpeed * Time.deltaTime;

            float angle = UtilsClass.GetAngleFromVectorFloat(moveDir);
            transform.eulerAngles = new Vector3(0, 0, angle);

            float destroySelfDistance = 1f;
            if (Vector3.Distance(transform.position, targetPosition) < destroySelfDistance)
            {
                if (ennemy.TryGetComponent<Ennemy_1>(out Ennemy_1 ennemy1))
                {
                    ennemy1.DamageEnnemy();
                }
                else
                {
                    ennemy.GetComponent<Ennemy_2>().DamageEnnemy();
                }
                Destroy(gameObject);
            }
        }
    }
}
