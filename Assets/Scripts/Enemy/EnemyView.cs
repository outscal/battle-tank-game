using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Interfaces;
using System;
using BTManager;
using StateMachine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyView : MonoBehaviour, ITakeDamage
    {
        private EnemyController enemyController;

        [SerializeField] private ChaseState chaseState;
        [SerializeField] private PetrolState petrolState;

        public ChaseState ChaseState { get { return chaseState; } }
        public PetrolState PetrolState { get { return petrolState; } }

        [SerializeField]
        private float radius;

        public event Action<Vector3> TargetDetected;
        public event Action<EnemyState> StateChangedEvent;

        public Vector3 targetPos { get; private set; }

        public int enemyIndex;

        void Start()
        {
            enemyController.DestroyEnemy += DestroyEnemy;
            petrolState.enabled = true;
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
            Player.PlayerManager.Instance.playerController.setPlayerScore(enemyController.getScoreIncreaser());
            EnemyManager.Instance.DestroyEnemy(enemyController);
            enemyController.DestroyEnemy -= DestroyEnemy;
            Destroy(gameObject);
        }

        public void DestroyEnemyView()
        {
            Destroy(gameObject);
        }

        public void FollowTarget(Vector3 targetPos)
        {
            if (GameManager.Instance.currentState.gameStateType == GameStateType.Replay) return;

            this.targetPos = targetPos;
            petrolState.enabled = false;
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

        public void TakeDamage(int damage)
        {
            enemyController.TakeDamage(damage);
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