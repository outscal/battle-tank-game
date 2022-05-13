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

    internal EnemyTankView EnemyTankView;

    public NavMeshAgent agent;
    public List<Transform> wayPoints = new List<Transform>();
    internal Transform player;

    public float distToPlayer;
    public float chaseRange;
    public float attackRange;

    public float timeBetweenAttack = 4f;
    public bool isAlreadyAttacked = false;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        EnemyTankView = GetComponent<EnemyTankView>();
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
