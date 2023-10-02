using UnityEngine;

namespace EnemyStates
{
    public class ChaseState : EnemyState
    {
        public ChaseState(EnemyView enemyView) : base(enemyView) { }

        public override void OnStateEnter()
        {
            enemyView.NavMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if (AssetManager.Instance.TankView == null) return;

            Vector3 target = AssetManager.Instance.TankView.transform.position;
            target -= 0.9f * enemyView.EnemyAttackRange * (target - enemyView.transform.position).normalized;
            
            enemyView.NavMeshAgent.SetDestination(target);
            
            if (enemyView.PlayerInAttackRange())
            {
                enemyView.SetState(new AttackState(enemyView));
            }
            else if(!enemyView.PlayerInDetectionRange())
            {
                enemyView.SetState(new PatrolState(enemyView));
            }
        }

        public override void OnStateExit()
        {
            enemyView.NavMeshAgent.isStopped = false;
        }
    }
}