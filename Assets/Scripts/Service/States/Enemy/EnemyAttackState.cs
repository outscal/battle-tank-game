using UnityEngine.AI;
using UnityEngine;
using Tanks.Service;
public class EnemyAttackState : StateInterface<EnemyView>
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
        //base.OnEnterState();
        Debug.Log("Entering Attack State");
        ObjectInitialization(stateObject);
        ShootSequence();
    }
    public void OnExitState(EnemyView stateObject)
    {
        Debug.Log("Exiting Attack State");
    }
    public void Update() 
    {
        Debug.Log("Update of Attack");
        timeElapsed += Time.deltaTime;

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
        if(timeElapsed >= 1 && enemyTank.remainingDistance <= enemyTank.stoppingDistance && target != null)
        {
            ShootSequence();
        }
        if(targetDistance > enemy.GetEnemyModel.AttackRadius && targetDistance <= enemy.GetEnemyModel.EngageRadius)
        {
            Debug.Log("Target Out of Fire Range");
            //ChaseState();
            enemy.stateMachine.ChangeState(new EnemyChaseState());
        }
        if(targetDistance > enemy.GetEnemyModel.EngageRadius)
        {
            Debug.Log("Target Escaped");
            //IdleState();
            enemy.stateMachine.ChangeState(new EnemyIdleState());
        }
    }
    void ShootSequence()
    {
        Debug.LogError("shooting");
        BulletSpawner.Instance.SpawnBullet(enemy.bulletSpawner.transform);
        timeElapsed = 0;
    }
}
