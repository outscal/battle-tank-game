using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrolState : StateInterface<EnemyView>
{
    private EnemyView enemy;
    private NavMeshAgent enemyTank;
    public void OnEnterState(EnemyView stateObject)
    {
        ObjectInitialization(stateObject);
        Patrol();
    }
    private void ObjectInitialization(EnemyView stateObject)
    {
        enemy = stateObject;
        enemyTank = enemy.GetComponent<NavMeshAgent>();
    }
    public void OnExitState(EnemyView stateObject)
    {
    }
    public void Update() 
    {   
        if(enemyTank.remainingDistance <= enemyTank.stoppingDistance)
        {
            enemy.stateMachine.ChangeState(new EnemyIdleState());
        }
        Vector3 origin = enemy.transform.position;
        Collider[] Objs = Physics.OverlapSphere(origin, enemy.GetEnemyModel.DetectionRadius);
        for(int i = 0; i < Objs.Length; i++)
        {
            if(Objs[i].GetComponent<TankView>())
            {
                enemy.stateMachine.ChangeState(new EnemyChaseState());
            }
        }
    }
    void Patrol()
    {
        enemyTank.stoppingDistance = 0.5f;
        int i = Random.Range(0, enemy.GetEnemyModel.patrolPoints.Length-1);
        enemyTank.SetDestination(enemy.GetEnemyModel.patrolPoints[i]);
    }
}
