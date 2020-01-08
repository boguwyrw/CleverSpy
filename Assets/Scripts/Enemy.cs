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
    private GameObject player;
    private float viewAngle;
    private bool enemySeePlayer;
    private float enemyRange;

    public List<Transform> waypointPath = new List<Transform>();

    // enemy shooting
    private float fireRate;
    private float nextFire;
    private Vector3 enemyBulletStartPosition;
    private float enemyBulletSpeed;
    private bool enemyStartsShooting;

    public GameObject enemyGun;
    public Rigidbody enemyBullet;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        targetWaypointIndex = Random.Range(0, waypointPath.Count);
        minimumDistance = 0.5f;
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        player = GameObject.FindGameObjectWithTag("Player");
        viewAngle = 120.0f;
        enemySeePlayer = false;
        enemyRange = 15.0f;
        navMeshAgent.speed = 6.0f;

        // enemy shooting
        fireRate = 1.0f;
        nextFire = Time.time;
        enemyBulletSpeed = 1200.0f;
        enemyStartsShooting = false;
    }

    private void FixedUpdate()
    {
        EnemyAngleOfView();
        if (!enemySeePlayer)
        {
            EnemyPatrolling();
        }
        else
        {
            EnemyChasingPlayer();
        }
    }

    private void EnemyPatrolling() // dziala :-)
    {
        if (Vector3.Distance(waypointPath[targetWaypointIndex].transform.position, transform.position) < minimumDistance)
        {
            targetWaypointIndex = Random.Range(0, waypointPath.Count); // losowe wybieranie punktu
        }

        navMeshAgent.SetDestination(waypointPath[targetWaypointIndex].transform.position);
    }

    private void EnemyChasingPlayer()
    {
        navMeshAgent.SetDestination(player.transform.position);
        EnemyShooting();
    }

    private void EnemyAngleOfView()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if (angle < viewAngle * 0.5f)
        {
            RaycastHit raycast;
            if (Physics.Raycast(transform.position + transform.up, direction.normalized, out raycast, enemyRange))
            {

                if (raycast.collider.gameObject.CompareTag("Player"))
                {
                    enemySeePlayer = true;
                    enemyStartsShooting = true;
                }
                else
                {
                    enemySeePlayer = false;
                    enemyStartsShooting = false;
                }

            }
        }

    }

    private void EnemyShooting()
    {
        enemyBulletStartPosition = enemyGun.transform.position;

        if (enemyStartsShooting)
        {
            if (Time.time > nextFire)
            {
                Rigidbody enemyBulletClone;
                enemyBulletClone = Instantiate(enemyBullet, enemyBulletStartPosition, transform.rotation);
                enemyBulletClone.velocity = transform.TransformDirection(Vector3.forward * enemyBulletSpeed * Time.deltaTime);
                nextFire = Time.time + fireRate;
            }
        }
    }

}
