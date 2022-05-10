using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankStateManager : MonoBehaviour
{
    public EnemyTankBaseState currentState;
    public EnemyTankPatrollingState patrollingState = new EnemyTankPatrollingState();
    public EnemyTankChaseState chaseState = new EnemyTankChaseState();
    public EnemyTankAttackState attackState = new EnemyTankAttackState();

    public NavMeshAgent agent;
    public List<Transform> wayPoints = new List<Transform>();
    public Transform player;

    public float distToPlayer;
    public float chaseRange = 10f;
    public float attackRange = 5f;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        player = FindObjectOfType<TankView>().transform;

        currentState = patrollingState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        distToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);

        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyTankBaseState enemyTankBaseState)
    {
        currentState = enemyTankBaseState;
        enemyTankBaseState.EnterState(this);
    }
}
