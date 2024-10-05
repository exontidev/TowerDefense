using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SocialPlatforms;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float radius = 5f;

    private EnemyMovement[] enemies => FindObjectsByType<EnemyMovement>(FindObjectsSortMode.None);
    private EnemyMovement closestEnemy;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] muzzles;
    public float cooldown;
    private bool canShot;

    private void Start()
    {
        InvokeRepeating("FindClosestEnemy", 0, 0.5f);
    }

    private void Update()
    {
        if(target)
            transform.LookAt(target);
    }

    private void FindClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        closestEnemy = null;

        foreach (EnemyMovement enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        // If there's an enemy within range, you can set it to target it
        if (closestDistance <= radius && closestEnemy != null)
        {
            this.target = closestEnemy.transform;
        }
        else
        {
            this.target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);  
    }
}
