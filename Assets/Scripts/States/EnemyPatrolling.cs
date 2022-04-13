using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class EnemyPatrolling : EnemyStates
{
    public override void OnEnterState()
    {
        base.OnEnterState();

    }
    protected override void Start()
    {
        base.Start();
        ChangeWalkPointSet();
    }
    private void Update()
    {
        if (enemyTankView.playerInSightRange && !enemyTankView.playerInAttackRange) enemyTankView.ChangeState(enemyTankView.chasingState);
        else if (enemyTankView.playerInSightRange && enemyTankView.playerInAttackRange) enemyTankView.ChangeState(enemyTankView.attackingState);

        Patrolling();
        ResetTurretRotation();
    }

    public async void ChangeWalkPointSet()
    {
        while (true)
        {
            
            enemyTankView.walkPointSet = false;
        }
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }
    //to do automatic patrolling by using navmesh
    private void Patrolling()
    {
        if (!enemyTankView.walkPointSet)
            SearchWalkPoint();
        if (enemyTankView.walkPointSet)
            enemyTankView.navMeshAgent.SetDestination(enemyTankView.walkPoint);
        Vector3 distanceToWalkPoint = enemyTankView.transform.position - enemyTankView.walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
            enemyTankView.walkPointSet = false;
    }
    // to find walkpoints to patrolling
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-enemyTankView.walkPointRange, enemyTankView.walkPointRange);
        float randomX = Random.Range(-enemyTankView.walkPointRange, enemyTankView.walkPointRange);
        enemyTankView.walkPoint = new Vector3(enemyTankView.transform.position.x + randomX, enemyTankView.transform.position.y, enemyTankView.transform.position.z + randomZ);
        if (Physics.Raycast(enemyTankView.walkPoint, -enemyTankView.transform.up, 2f, enemyTankView.groundMask))
            enemyTankView.walkPointSet = true;

    }
    // to reset tuuret forward to tank direction
    private void ResetTurretRotation()
    {
        if (enemyTankView.Turret.transform.rotation.eulerAngles.y - enemyTankView.transform.rotation.eulerAngles.y > 1
                || enemyTankView.Turret.transform.rotation.eulerAngles.y - enemyTankView.transform.rotation.eulerAngles.y < -1)
        {
            Vector3 desiredRotation = Vector3.up * enemyTankView.turretRotationRate * Time.deltaTime;
            enemyTankView.Turret.transform.Rotate(desiredRotation, Space.Self);
        }
    }
}