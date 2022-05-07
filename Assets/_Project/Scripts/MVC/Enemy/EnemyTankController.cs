using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController
{
    public EnemyTankView EnemyTankView { get; }
    public EnemyTankModel EnemyTankModel { get; }
    public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankPrefab, Vector3 spawnPlayer)
    {
        EnemyTankModel = tankModel;
        EnemyTankView = Object.Instantiate(tankPrefab);
        Debug.Log("Tank View Created", EnemyTankView);
        EnemyTankView.EnemyTankController = this;
        tankPrefab.transform.position = spawnPlayer;
        //OnEnableFunction();
        //FireControl();
    }

    internal void InitializeVariables()
    {
        EnemyTankView.m_PlayerPosition = Vector3.zero;
        EnemyTankView.m_IsPatrol = true;
        EnemyTankView.m_CaughtPlayer = false;
        EnemyTankView.m_playerInRange = false;
        EnemyTankView.m_PlayerNear = false;
        EnemyTankView.m_WaitTime = EnemyTankModel.startWaitTime;
        EnemyTankView.m_TimeToRotate = EnemyTankModel.timeToRotate;

        EnemyTankView.m_CurrentWaypointIndex = 0;

        EnemyTankView.navMeshAgent.isStopped = false;
        EnemyTankView.navMeshAgent.speed =EnemyTankModel.SpeedWalk;
        EnemyTankView.navMeshAgent.SetDestination(EnemyTankView.waypoints[EnemyTankView.m_CurrentWaypointIndex].position);
    }

    public void UpdateFunction()
    {
       EnviromentView();

            if (!EnemyTankView.m_IsPatrol)
            {
                Chasing();
            }
            else
            {
                Patroling();
            }
    }
    public void Chasing()
    {
        EnemyTankView.m_PlayerNear = false;
        EnemyTankView.playerLastPosition = Vector3.zero;

        if (!EnemyTankView.m_CaughtPlayer)
        {
            Move(EnemyTankModel.SpeedRun);
            EnemyTankView.navMeshAgent.SetDestination(EnemyTankView.m_PlayerPosition);
        }
        if (EnemyTankView.navMeshAgent.remainingDistance <= EnemyTankView.navMeshAgent.stoppingDistance)
        {
            if (EnemyTankView.m_WaitTime <= 0 && !EnemyTankView.m_CaughtPlayer && Vector3.Distance(EnemyTankView.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
            {

                EnemyTankView.m_IsPatrol = true;
                EnemyTankView.m_PlayerNear = false;
                Move(EnemyTankModel.SpeedWalk);
                EnemyTankView.m_TimeToRotate = EnemyTankModel.timeToRotate;
                EnemyTankView.m_WaitTime = EnemyTankModel.startWaitTime;
                EnemyTankView.navMeshAgent.SetDestination(EnemyTankView.waypoints[EnemyTankView.m_CurrentWaypointIndex].position);
            }
            else
            {
                if (Vector3.Distance(EnemyTankView.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                {
                    Stop();
                }
                EnemyTankView.m_WaitTime -= Time.deltaTime;
            }
        }
    }


    private void Patroling()
    {
        if (EnemyTankView.m_PlayerNear)
        {
            if (EnemyTankView.m_TimeToRotate <= 0)
            {
                Move(EnemyTankModel.SpeedWalk);
                LookingPlayer(EnemyTankView.playerLastPosition);
            }
            else
            {
                Stop();
                EnemyTankView.m_TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            EnemyTankView.m_PlayerNear = false;
            EnemyTankView.playerLastPosition = Vector3.zero;
            EnemyTankView.navMeshAgent.SetDestination(EnemyTankView.waypoints[EnemyTankView.m_CurrentWaypointIndex].position);
            if (EnemyTankView.navMeshAgent.remainingDistance <= EnemyTankView.navMeshAgent.stoppingDistance)
            {
                if (EnemyTankView.m_WaitTime <= 0)
                {
                    NextPoint();
                    Move(EnemyTankModel.SpeedWalk);
                    EnemyTankView.m_WaitTime = EnemyTankModel.startWaitTime;
                }
                else
                {
                    Stop();
                    EnemyTankView.m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }


    public void NextPoint()
    {
        EnemyTankView.m_CurrentWaypointIndex = (EnemyTankView.m_CurrentWaypointIndex + 1) % EnemyTankView.waypoints.Length;
        EnemyTankView.navMeshAgent.SetDestination(EnemyTankView.waypoints[EnemyTankView.m_CurrentWaypointIndex].position);
    }

    void Stop()
    {
        EnemyTankView.navMeshAgent.isStopped = true;
        EnemyTankView.navMeshAgent.speed = 0;
    }

    void Move(float speed)
    {
        EnemyTankView.navMeshAgent.isStopped = false;
        EnemyTankView.navMeshAgent.speed = speed;
    }

    void CaughtPlayer()
    {
        EnemyTankView.m_CaughtPlayer = true;
    }

    void LookingPlayer(Vector3 player)
    {
        EnemyTankView.navMeshAgent.SetDestination(player);
        if (Vector3.Distance(EnemyTankView.transform.position, player) <= 0.3)
        {
            if (EnemyTankView.m_WaitTime <= 0)
            {
                EnemyTankView.m_PlayerNear = false;
                Move(EnemyTankModel.SpeedWalk);
                EnemyTankView.navMeshAgent.SetDestination(EnemyTankView.waypoints[EnemyTankView.m_CurrentWaypointIndex].position);
                EnemyTankView.m_WaitTime = EnemyTankModel.startWaitTime;
                EnemyTankView.m_TimeToRotate = EnemyTankModel.timeToRotate;
            }
            else
            {
                Stop();
                EnemyTankView.m_WaitTime -= Time.deltaTime;
            }
        }
    }

    void EnviromentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(EnemyTankView.transform.position, EnemyTankView.viewRadius, EnemyTankView.playerMask);

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - EnemyTankView.transform.position).normalized;
            if (Vector3.Angle(EnemyTankView.transform.forward, dirToPlayer) < EnemyTankView.viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(EnemyTankView.transform.position, player.position);
                if (!Physics.Raycast(EnemyTankView.transform.position, dirToPlayer, dstToPlayer, EnemyTankView.obstacleMask))
                {
                    EnemyTankView.m_playerInRange = true;
                    EnemyTankView.m_IsPatrol = false;
                }
                else
                {
                    EnemyTankView.m_playerInRange = false;
                }
            }
            if (Vector3.Distance(EnemyTankView.transform.position, player.position) > EnemyTankView.viewRadius)
            {
                EnemyTankView.m_playerInRange = false;
            }
            if (EnemyTankView.m_playerInRange)
            {
                EnemyTankView.m_PlayerPosition = player.transform.position;
            }
        }
    }
}
