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
    //public Transform player;


    private void Start()
    {
        currentState = patrollingState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyTankBaseState enemyTankBaseState)
    {
        currentState = enemyTankBaseState;
        enemyTankBaseState.EnterState(this);
    }
}
