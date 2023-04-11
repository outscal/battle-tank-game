using BattleTank.Interface;
using BattleTank.StateMachine.EnemyState;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.EnemyTank
{
    [RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
    public class EnemyTankView : MonoBehaviour, IDamageable
    {
        private EnemyTankController enemyTankController;
        [SerializeField] private List<MeshRenderer> tankRenderer;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private EnemyStateMachine enemyStateMachine;

        private void Start()
        {
            enemyTankController.UpdateTankColor(tankRenderer);
        }
        
        public void SetEnemyTankController(EnemyTankController _enemyTankController)
        {
            enemyTankController = _enemyTankController;
        }

        public Transform GetBulletTransform()
        {
            return bulletSpawnPoint;
        }

        public NavMeshAgent GetNavMeshAgent()
        {
            return agent;
        }

        public EnemyStateMachine GetEnemyStateMachine()
        {
            return enemyStateMachine;
        }

        public void Damage(float damage)
        {
            enemyTankController.TakeDamage(damage);
        }
    }
}