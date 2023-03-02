using UnityEngine.AI;
using UnityEngine;
using Tanks.Service;
using Tank.EventService;
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
        ObjectInitialization(stateObject);
        ShootSequence();
    }
    public void OnExitState(EnemyView stateObject)
    {
    }
    public void Update() 
    {
        timeElapsed += Time.deltaTime;
        Vector3 origin = enemy.transform.position;
        Collider[] Objs = Physics.OverlapSphere(origin, enemy.GetEnemyModel.EngageRadius);
        for(int i = 0; i < Objs.Length; i++)
        {
            if(Objs[i].GetComponent<TankView>())
            {
                target = Objs[i].gameObject.transform.position;
                enemy.transform.LookAt(target);
            }
        }
        float targetDistance = Vector3.Distance(enemy.transform.position, target);
        if (timeElapsed >= 1 && enemyTank.remainingDistance <= enemyTank.stoppingDistance && target != null)
        {
            ShootSequence();
        }
        if (targetDistance > enemy.GetEnemyModel.AttackRadius && targetDistance <= enemy.GetEnemyModel.EngageRadius)
        {
            enemy.stateMachine.ChangeState(new EnemyChaseState());
        }
        if(targetDistance > enemy.GetEnemyModel.EngageRadius)
        {
            enemy.stateMachine.ChangeState(new EnemyIdleState());
        }
    }
    void ShootSequence()
    {
        BulletSpawner.Instance.SpawnBullet(enemy.bulletSpawner.transform, enemy.GetEnemyModel.Type);
        timeElapsed = 0;
    }
}
