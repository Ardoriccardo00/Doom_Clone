using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
    }    

    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 20)
        {
            print("Attack");
            //agent.SetDestination(player.transform.position);
        }
    }
} 