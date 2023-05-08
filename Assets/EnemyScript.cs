using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public Transform[] waypoints;
    public float detectionRange;
    public float chaseSpeed;
    public float patrolSpeed;

    private NavMeshAgent agent;
    private Transform player;
    private int currentWaypoint = 0;
    private bool isChasing = false;
    public GameObject deathScreen;

    public float aggression = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = patrolSpeed + aggression;
        agent.SetDestination(waypoints[currentWaypoint].position);
    }

    void Update()
    {
        if (isChasing)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                agent.SetDestination(waypoints[currentWaypoint].position);
            }

            if (Vector3.Distance(transform.position, player.position) < detectionRange)
            {
                transform.LookAt(player.position);
                isChasing = true;
                agent.speed = chaseSpeed + aggression;
            }
        }

        if (isChasing && Vector3.Distance(transform.position, player.position) > detectionRange * 2)
        {
            isChasing = false;
            agent.speed = patrolSpeed + aggression;
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            deathScreen.SetActive(true);
            FindObjectOfType<PlayerScript>().enabled = false;
        }
    }
}
