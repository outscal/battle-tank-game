using UnityEngine;

namespace EnemyStates
{
    public class AttackState : EnemyState
    {
        public AttackState(EnemyView enemyView) : base(enemyView) { }

        private float m_NextFireTime = 0f;

        public override void OnStateEnter()
        {
            enemyView.NavMeshAgent.isStopped = true;
        }

        public override void Tick()
        {
            if (!enemyView.PlayerInAttackRange())
            {
                if(enemyView.PlayerInDetectionRange())
                    enemyView.SetState(new ChaseState(enemyView));
                else
                    enemyView.SetState(new PatrolState(enemyView));
            }
            else
            {
                // Attack Player
                Shoot();
                enemyView.NavMeshAgent.isStopped = true;
            }
        }

        public override void OnStateExit()
        {
            enemyView.NavMeshAgent.isStopped = false;
        }

        private void Shoot()
        {
            if (AssetManager.Instance.TankView == null) return;

            Vector3 directionToPlayer = (AssetManager.Instance.TankView.transform.position - enemyView.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0, directionToPlayer.z));
            enemyView.transform.rotation = lookRotation;

            if (Time.time >= m_NextFireTime)
            {
                AssetManager.Instance.ShellService.SpawnShell(enemyView.transform, enemyView.ShellLayer, enemyView.Damage);
                m_NextFireTime = Time.time + enemyView.FireRate;
            }
        }
    }
}