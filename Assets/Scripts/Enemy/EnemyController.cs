using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    private EnemyModel enemymodel;
    public NavMeshAgent navMeshAgent;
    private EnemyView enemyView;
    private Transform playerTank;
    private PlayerTankView _playerTankView;
    public float chaseDistance;
     public float stoppingDistance = 8f;



    public EnemyController(PlayerTankView playerTankView, EnemyModel _model, EnemyView _view, Transform _playerTank, float _chaseDistance)
    {
        _playerTankView = playerTankView;
        enemymodel = _model;
        enemyView = _view;
        playerTank = _playerTank;
        chaseDistance = _chaseDistance;
    }


    public void MoveTowardsPlayer()
    {
        if(enemyView == null || navMeshAgent == null) return;
        navMeshAgent.SetDestination(_playerTankView.transform.position);
    }


    public void TakeDamage(float damage)
    {
        enemymodel.Health -= damage;

        // Update the color of the enemy based on its health
        if (enemymodel.Health > 0)
        {
            enemyView.UpdateColor(Color.green);
        }
        else
        {
            enemyView.UpdateColor(Color.red);
        }
    }


}
