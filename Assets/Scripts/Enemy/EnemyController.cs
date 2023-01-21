using System;
using System.Collections;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    public EnemyModel enemymodel;
    public NavMeshAgent navMeshAgent;
    public EnemyView enemyView;
    public Transform playerTank;
    public PlayerTankView _playerTankView;
    public float chaseDistance;

    public EnemyTankType EnemyTankType { get; set; }

    public EnemyController(PlayerTankView playerTankView, EnemyModel _model, EnemyView _view, Transform _playerTank, float _chaseDistance)
    {
        _playerTankView = playerTankView;
        enemymodel = _model;
        enemyView = _view;
        playerTank = _playerTank;
        chaseDistance = _chaseDistance;
        EnemyTankType = _model.EnemyTankType;
        enemyView.SetEnemyTankController(this);
    }

    public void MoveTowardsPlayer()
    {
        if (enemyView == null || navMeshAgent == null) return;
        navMeshAgent.SetDestination(_playerTankView.transform.position);
        
    }




}
