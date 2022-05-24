using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStatesMachine : MonoBehaviour
{
    public EnemyTankView EnemyView;
    [HideInInspector]public Transform playerTransform;
    [HideInInspector]public State currentState;
    [HideInInspector]public Patrol PatrolState = new Patrol();
    [HideInInspector]public Chase ChaseState = new Chase();
    [HideInInspector]public State AttackState = new Attack();
    
    [HideInInspector]public State activeState;
   
    public LayerMask whatIsGround; 
    public LayerMask whatIsPlayer;
    public NavMeshAgent agent;    
    public float walkPointRange, sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    
    public bool walkPointSet = false;    
    [HideInInspector]public Vector3 walkPoint;

    
    protected void Awake()
    {
        EnemyView = GetComponent<EnemyTankView>();
    }

    void Start()
    {   
       currentState = PatrolState;
       currentState.OnStateEnter(this);
    }

    
    void FixedUpdate()
    {
        CheckPlayerInRange();
        currentState.OnUpdate(this);        
    }

    private void CheckPlayerInRange()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    }

    public void CoroutineStart()
    {
        StartCoroutine(EnemyView.TimeBetweenAttack());   
    }

    public void ChangeState(State _state)
    {
        if(currentState != null)
        {
            currentState.OnStateExit(this);
        }

        currentState = _state;
        currentState.OnStateEnter(this);
    } 


}
