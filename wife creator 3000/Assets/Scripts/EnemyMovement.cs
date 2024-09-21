using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform endPoint => GameObject.FindGameObjectWithTag("Finish").transform;

    [SerializeField] private EnemyData data;
    private Vector3 targetPosition => endPoint.position;

    private void Start()
    {
        
        agent.speed = data.speed;
        agent.destination = (targetPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
            Destroy(gameObject);
    }
}
