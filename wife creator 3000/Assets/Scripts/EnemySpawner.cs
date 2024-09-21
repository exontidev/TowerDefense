using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 1f);
    }

    private void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity, transform);
    }
}
