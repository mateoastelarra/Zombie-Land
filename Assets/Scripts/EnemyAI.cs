using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;

    private void Start() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() 
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
            FollowTarget();

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
            AttackTarget();
    }

    private void FollowTarget()
    { 
        navMeshAgent.SetDestination(target.transform.position); 
    }

    private void AttackTarget()
    {
        Debug.Log("Attack");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
