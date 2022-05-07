using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(Image))]

public class EnemyTankView : MonoBehaviour
{

    public EnemyTankController EnemyTankController;
    //private TankState currentState;
    //public TankState startingState;
    //public TankPatrollingState tankPatrollingState;
    //public TankChasingState tankChasingState;


    public NavMeshAgent navMeshAgent;

    public float viewRadius = 15;
    public float viewAngle = 90;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public float meshResolution = 1.0f;
    public int edgeIterations = 4;
    public float edgeDistance = 0.5f;

    public Transform[] waypoints;
    internal int m_CurrentWaypointIndex;

    internal Vector3 playerLastPosition = Vector3.zero;
    internal Vector3 m_PlayerPosition;

    internal float m_WaitTime;
    internal float m_TimeToRotate;
    internal bool m_playerInRange;
    internal bool m_PlayerNear;
    internal bool m_IsPatrol;
    internal bool m_CaughtPlayer;

    private Image image;


    private void Awake()
    {
        InitializeComponenet();
    }
    private void Start()
    {
        //ChangeState(startingState);
        EnemyTankController.InitializeVariables();
    }

    private void Update()
    {
        EnemyTankController.UpdateFunction();
    }
    private void InitializeComponenet()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //image = GetComponent<Image>();
        //startingState.EnemyTankView = this;
    }
    public void ChaseState()
    {
        EnemyTankController.Chasing();
    }

    public void PatrollingState()
    {

    }

    //public void ChangeState(TankState newState)
    //{
    //    if (currentState != null)
    //    {
    //        currentState.OnExitState();
    //    }

    //    currentState = newState;
    //    currentState.OnEnterState();
    //}

    public void ChangeColor(Color color)
    {
        image.color = color;
    }
}
