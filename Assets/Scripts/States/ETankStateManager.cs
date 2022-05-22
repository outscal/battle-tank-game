using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ETankStateManager : MonoBehaviour
{
    public ETankBaseState currentState;
    public ETankPatrollingState patrollingState = new ETankPatrollingState();
    public ETankChaseState chaseState = new ETankChaseState();
    public ETankAttackState attackState = new ETankAttackState();

    internal ETankView EnemyTankView;

    public NavMeshAgent agent;
    public List<Transform> wayPoints = new List<Transform>();
    internal Transform player;

    public float distToPlayer;
    public float chaseRange;
    public float attackRange;

    public float timeBetweenAttack = 2f;
    public bool isAlreadyAttacked = false;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        EnemyTankView = GetComponent<ETankView>();
        player = FindObjectOfType<TankView>().transform;

        currentState = patrollingState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        CheckPlayer();
        currentState.UpdateState(this);
    }

    private void CheckPlayer()
    {
        if (player == null)
        {
            currentState = patrollingState;
            return;
        }
        distToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
    }

    public void SwitchState(ETankBaseState enemyTankBaseState)
    {
        currentState = enemyTankBaseState;
        enemyTankBaseState.EnterState(this);
    }
}