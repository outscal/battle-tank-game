using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : StateInterface<EnemyView>
{
    
    private float timeElapsed;
    private EnemyView enemy;
    private NavMeshAgent enemyTank;
    private Vector3 target;
    private void ObjectInitialization(EnemyView stateObject)
    {
        enemy = stateObject;
        enemyTank = enemy.GetComponent<NavMeshAgent>();
    }
    public void OnEnterState(EnemyView stateObject)
    {
        ObjectInitialization(stateObject);
        Chase();
    }
    public void OnExitState(EnemyView stateObject)
    {
    }
    public void Update() 
    {
        Vector3 origin = enemy.transform.position;
        Collider[] Objs = Physics.OverlapSphere(origin, enemy.GetEnemyModel.EngageRadius);
        for(int i = 0; i < Objs.Length; i++)
        {
            if(Objs[i].GetComponent<TankView>())
            {
                target = Objs[i].gameObject.transform.position;
            }
        }
        float targetDistance = Vector3.Distance(enemy.transform.position, target);
        if(targetDistance <= enemy.GetEnemyModel.AttackRadius)
        {
    
            enemy.stateMachine.ChangeState(new EnemyAttackState());
        }
        if(targetDistance > enemy.GetEnemyModel.EngageRadius)
        {
            enemy.stateMachine.ChangeState(new EnemyIdleState());
        }
    }
    void Chase()
    {
        Vector3 origin = enemy.transform.position;
        Collider[] Objs = Physics.OverlapSphere(origin, enemy.GetEnemyModel.EngageRadius);
        for(int i = 0; i < Objs.Length; i++)
        {
            if(Objs[i].GetComponent<TankView>())
            {
                target = Objs[i].gameObject.transform.position;
            }
        }
        enemyTank.stoppingDistance = enemy.GetEnemyModel.AttackRadius;
        enemyTank.destination = target;
    }
}

