using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.Enemy
{
    public class EnemyAttackState : EnemyState
    {
        private Transform playerTransform;
        private Rigidbody rb;
        private NavMeshAgent agent;
        private Vector3 tankLookDirection;

        private float distanceToPlayer;
        private float timeSinceShot;
        private float rotationSpeed;

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            agent = enemyView.GetAgent();
            rb = enemyView.GetRigidbody();
            playerTransform = enemyView.GetPlayerTransform();
            rotationSpeed = enemyView.GetEnemyRotationSpeed();

            agent.ResetPath();
            rb.velocity = Vector3.zero;
            timeSinceShot = 0f;
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        public override void Tick()
        {
            base.Tick();

            if (playerTransform == null)
            {
                enemyView.ChangeState(enemyView.enemyIdleState);
                return;
            }

            Attack();
        }

        private void Attack()
        {
            distanceToPlayer = Vector3.Distance(rb.transform.position, playerTransform.position);
            tankLookDirection = (playerTransform.position - rb.transform.position).normalized;

            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.LookRotation(tankLookDirection), rotationSpeed);

            if (distanceToPlayer < enemyView.GetEnemyVisibilityRange())
                EnemyShoot();
            else
                enemyView.ChangeState(enemyView.enemyChaseState);
        }

        private void EnemyShoot()
        {
            timeSinceShot += Time.deltaTime;
            if (timeSinceShot > (60 / enemyView.GetEnemyBPM()))
            {
                enemyView.EnemyShootBullet();
                timeSinceShot = 0;
            }
        }
    }
}
