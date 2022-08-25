using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankServices;
using UnityEngine.AI;

namespace EnemyTankServices
{
    public class EnemyTankView : MonoBehaviour
    {
        public EnemyTankController enemyTankController;
        [HideInInspector] public Transform playerTransform;
        public NavMeshAgent navAgent;

        public LayerMask playerLayerMask; // For player detection.
        public LayerMask groundLayerMask; // For ground detection.

        public EnemyPatrollingState patrollingState; // Patrolling behaviour script.
        
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

        // To set initial state of enemy tank.
        private void InitializeState()
        {
            switch (initialState)
            {
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
