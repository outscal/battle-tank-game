using UnityEngine;
using UnityEngine.AI;
public class EnemyChaseState : EnemyState
{
    private Transform playerTransform;
    private NavMeshAgent agent;
    private float playerDetectionRange;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        playerTransform = enemyView.GetPlayerTransform();
        agent = enemyView.GetAgent();
        playerDetectionRange = enemyView.GetEnemyDetectionRange();

        agent.SetDestination(playerTransform.position);
        agent.stoppingDistance = 0f;
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
    public override void Tick()
    {
        base.Tick();
        Chase();
    }
    public void Chase()
    {
        if (playerTransform == null)
        {
            enemyView.ChangeState(enemyView.enemyIdleState);
            return;
        }
        if (agent.remainingDistance > playerDetectionRange + 10f)
        {
            enemyView.ChangeState(enemyView.enemyIdleState);
        }
        else if (agent.remainingDistance < enemyView.GetEnemyVisibilityRange())
        {
            enemyView.ChangeState(enemyView.enemyAttackState);
        }
        else
        {
            agent.SetDestination(playerTransform.position);
        }
    }
}
