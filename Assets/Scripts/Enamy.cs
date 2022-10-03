using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EnamyState
{
    chase,
    attack
}

public class Enamy : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Transform playerTarget;
    public float moveSpeed  = 3.5f;
    public float attackDistance = 1.0f;
    public float attackPlayerAfterAttackDistance = 1f;
    private float WaitBeforeAttackTIme = 3f;
    private float attackTimer;
    private EnamyState enamyState;
    private Animator enamyAnim;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.Find("Player").transform;
        enamyAnim = GetComponent<Animator>();
    }
    void Start()
    {
        enamyState = EnamyState.chase;
        attackTimer = WaitBeforeAttackTIme;
        
    }

   
    void Update()
    {
        if(enamyState == EnamyState.chase)
        {
            ChasePlayer();
        }
        if(enamyState == EnamyState.attack)
        {
            AttackPlayer();
        }
    }
    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = moveSpeed;
        if (navAgent.velocity.sqrMagnitude == 0)
        {
            enamyAnim.SetBool("foward", false);
        }
        else
        {
            enamyAnim.SetBool("foward", true);
        }

        if(Vector3.Distance(transform.position , playerTarget.position) <= attackDistance)
        {
            enamyState = EnamyState.attack;
        }
    }
    void AttackPlayer()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        enamyAnim.SetBool("foward", false);
        attackTimer += Time.deltaTime;
        if(attackTimer > WaitBeforeAttackTIme)
        {
            enamyAnim.SetBool("attack", true);
            attackTimer = 0f;
        }
        if(Vector3.Distance(transform.position , playerTarget.position) > attackDistance + attackPlayerAfterAttackDistance)
        {
            navAgent.isStopped = false;
            enamyState = EnamyState.chase;
        }
        
        

    }
}
