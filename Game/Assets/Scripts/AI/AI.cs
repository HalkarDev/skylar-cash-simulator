using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //Script for behavior of nextbots
    private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask WhatIsPlayer;
    private bool nearPlayer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        nearPlayer = Physics.CheckSphere(transform.position, 10, WhatIsPlayer);
        if (!nearPlayer)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(transform.position);
            Health.Health1 -= 100;
        }
    }
}
