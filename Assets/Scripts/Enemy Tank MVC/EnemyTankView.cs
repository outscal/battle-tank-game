using GameServices;
using System.Collections.Generic;
using UnityEngine;
using TankServices;
using UnityEngine.AI;
using AllServices;
//using EnemyTankServices;

namespace EnemyTankServices
{
    public class EnemyTankView : MonoBehaviour, IDamagable
    {
        public EnemyTankController enemyTankController; 
        [HideInInspector] public Transform playerTransform; // Reference to player position.
        public NavMeshAgent navAgent;
        public Transform turret;

        public Transform fireTransform; // Bullet spawn position.
        public LayerMask playerLayerMask; // For player detection.
        public LayerMask groundLayerMask; // For ground detection.

        public EnemyPatrollingState patrollingState; // Patrolling behaviour script.
        public EnemyChasingState chasingState; // Chasing behaviour script.
        public EnemyAttackingState attackingState; // Attacking behaviour script.

        [SerializeField] private EnemyState initialState;
        [HideInInspector] public EnemyState activeState;
        [HideInInspector] public EnemyTankBaseStates currentState;

        private void Start()
        {

            // If player is spawnned, we take reference of player transform.
            if (TankService.Instance.playerTankView)
            {
                playerTransform = TankService.Instance.playerTankView.transform;
            }
            navAgent = GetComponent<NavMeshAgent>();
            SetEnemyTankColor();
            InitializeState();
        }

        private void FixedUpdate()
        {
            enemyTankController.RangeCheck();            
        }

        public void SetTankControllerReference(EnemyTankController enemyController)
        {
            enemyTankController = enemyController;
        }

        // Sets material color of all child mesh renderers.
        public void SetEnemyTankColor()
        {
            MeshRenderer[] renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = enemyTankController.enemyTankModel.tankColor;
            }
        }

        // Returns random launch force value between minimum and maximum lauch force.
        public float GetRandomLaunchForce()
        {
            return Random.Range(enemyTankController.enemyTankModel.minLaunchForce, enemyTankController.enemyTankModel.maxLaunchForce);
        }

        // Implementation of IDamagable interface. 
        public void TakeDamage(int damage)
        {
            enemyTankController.TakeDamage(damage);
        }

        public void Death()
        {
            // Removes reference of tank position in camera targets list.
            CameraController.Instance.RemoveCameraTargetPosition(this.transform);
            Destroy(gameObject);
        }

        // To set initial state of enemy tank.
        private void InitializeState()
        {
            switch (initialState)
            {
                case EnemyState.Attacking:
                    {
                        currentState = attackingState;
                        break;
                    }
                case EnemyState.Chasing:
                    {
                        currentState = chasingState;
                        break;
                    }
                case EnemyState.Patrolling:
                    {
                        currentState = patrollingState;
                        break;
                    }
                default:
                    {
                        currentState = null;
                        break;
                    }
            }
            currentState.OnStateEnter();
        }
    }
}
