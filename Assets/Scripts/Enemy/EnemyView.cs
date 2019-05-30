using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Interfaces;
using System;
using Manager;
using StateMachine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyView : MonoBehaviour, ITakeDamage
    {
        private EnemyController enemyController;

        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private ChaseView chaseState;
        [SerializeField] private PetrolView petrolState;

        public NavMeshAgent Agent{ get { return agent; }}
        public ChaseView ChaseState { get { return chaseState; } }
        public PetrolView PetrolState { get { return petrolState; } }

        [SerializeField]
        private float radius;

        public event Action<Vector3> TargetDetected;
        public event Action<EnemyState> StateChangedEvent;

        public int shooterID { get; private set; }

        public Vector3 targetPos { get; private set; }

        public int enemyIndex;

        private IGameManager gameManager;
        private IEnemy enemyManager;

        void Start()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            agent.speed = enemyController.enemyModel.scriptableObj.moveSpeed;
            enemyController.DestroyEnemy += DestroyEnemy;
        }

        public EnemyController GetEnemyController()
        {
            return enemyController;
        }

        public void SetEnemyController(EnemyController enemyController)
        {
            this.enemyController = enemyController;
        }

        public void StateChangedMethod(EnemyState enemyState)
        {
            StateChangedEvent?.Invoke(enemyState);
        }

        private void DestroyEnemy()
        {
            for (int i = 0; i < Player.PlayerManager.Instance.playerControllerList.Count; i++)
            {
                if(PlayerManager.Instance.playerControllerList[i].playerID == shooterID)
                {
                    PlayerManager.Instance.playerControllerList[i].setPlayerScore(enemyController.GetScoreIncreaser());
                    break;
                }
            }

            //enemyManager.Reset(enemyController);
            //enemyController.DestroyEnemy -= DestroyEnemy;
            ResetEnemyView();
            //Destroy(gameObject);
        }

        private void ResetEnemyView()
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

        public void FollowTarget(Vector3 targetPos)
        {
            if (gameManager.GetCurrentState().gameStateType == GameStateType.Replay) return;

            petrolState.enabled = false;
            SetEnemyData(targetPos);
            agent.destination = targetPos;
            StateChangedEvent?.Invoke(EnemyState.chase);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerView>() != null)
                TargetDetected?.Invoke(other.transform.position);
        }

        public int DamageValue()
        {
            return enemyController.enemyModel.scriptableObj.damage;
        }

        public void SetEnemyData(Vector3 positions)
        {
            if (enemyManager == null)
                enemyManager = StartService.Instance.GetService<IEnemy>();

            EnemyData enemyData = new EnemyData();
            enemyData.wayPoints = new List<Vector3>();
            enemyData = enemyManager.GetEnemyData(enemyIndex);
            enemyData.wayPoints.Add(positions);
            enemyManager.SetEnemyData(enemyIndex, enemyData);
        }

        public void TakeDamage(int damage, int shooterID)
        {
            enemyController.TakeDamage(damage);
            this.shooterID = shooterID;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, 15);

            UnityEditor.Handles.color = Color.red;
            UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, radius);
        }
#endif

    }
}