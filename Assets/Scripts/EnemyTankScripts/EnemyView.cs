using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.Enemy
{
    public class EnemyView : MonoBehaviour, IDamageable
    {
        private EnemyController enemyController;
        private EnemyState currentState;

        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform gun;
        [SerializeField] private NavMeshAgent agent;

        [SerializeField] public EnemyAttackState enemyAttackState;
        [SerializeField] public EnemyChaseState enemyChaseState;
        [SerializeField] public EnemyIdleState enemyIdleState;
        [SerializeField] public EnemyPatrolState enemyPatrolState;

        private void Start()
        {
            agent.speed = GetEnemySpeed();
            agent.stoppingDistance = 1f;

            ChangeState(enemyIdleState);
        }

        public Rigidbody GetRigidbody()
        {
            return rb;
        }

        public Transform GetGun()
        {
            return gun;
        }

        public NavMeshAgent GetAgent()
        {
            return agent;
        }

        public int GetEnemyStrength()
        {
            return enemyController.GetStrength();
        }

        public float GetEnemyVisibilityRange()
        {
            return enemyController.GetVisibilityRange();
        }

        public float GetEnemyDetectionRange()
        {
            return enemyController.GetDetectionRange();
        }

        public float GetEnemyBPM()
        {
            return enemyController.GetBulletsPerMinute();
        }

        public float GetEnemySpeed()
        {
            return enemyController.GetSpeed();
        }

        public float GetEnemyRotationSpeed()
        {
            return enemyController.GetRotationSpeed();
        }

        public void TakeDamage(int damage, TankType tankType)
        {
            if (tankType == TankType.Player)
                enemyController.TakeDamage(damage);
        }

        public void EnemyShootBullet()
        {
            enemyController.Shoot(gun);
        }

        public Transform GetPlayerTransform()
        {
            return enemyController.GetPlayerTransform();
        }

        public void SetEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }

        public void ChangeState(EnemyState newState)
        {
            if (currentState != null)
            {
                currentState.OnStateExit();
            }
            currentState = newState;
            currentState.OnStateEnter();
        }

        private void Update()
        {
            currentState.Tick();
        }
    }
}
