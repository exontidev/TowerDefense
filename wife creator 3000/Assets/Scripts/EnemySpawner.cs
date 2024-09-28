using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float countdown = 3f;
    [SerializeField] private float timeBetweenEnemySpawn;

    private int wave;

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(countdown);
        for (int i = 0; i < wave; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(timeBetweenEnemySpawn);
        }
        wave++;
        StartCoroutine(SpawnWave());
    }
}
