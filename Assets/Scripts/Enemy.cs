using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private int targetWaypointIndex;
    private float minimumDistance;
    private Rigidbody enemyRigidbody;

    public List<Transform> waypointPath = new List<Transform>();

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetWaypointIndex = 0;
        minimumDistance = 0.5f;
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        EnemyPatrolling();
    }

    private void EnemyPatrolling() // dziala :-)
    {
        if (Vector3.Distance(waypointPath[targetWaypointIndex].transform.position, transform.position) < minimumDistance)
        {
            targetWaypointIndex = Random.Range(0, waypointPath.Count); // losowe wybieranie punktu
        }

        navMeshAgent.SetDestination(waypointPath[targetWaypointIndex].transform.position);
    }

}
