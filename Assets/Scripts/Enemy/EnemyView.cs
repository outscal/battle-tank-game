using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
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

        [SerializeField]
        private float radius;

        public event Action<Vector3> TargetDetected;

        void Start()
        {
            enemyController.DestroyEnemy += DestroyEnemy;
        }

        public void SetEnemyController(EnemyController enemyController)
        {
            this.enemyController = enemyController;
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

                if (transform != null)
                transform.LookAt(targetPos);
        }

        void Update()
        {
            DetectTarget();
        }

        void DetectTarget()
        {
            var hitCollider = Physics.OverlapSphere(transform.position, radius);
            for (int i = 0; i < hitCollider.Length; i++)
            {
                if(hitCollider[i].GetComponent<Player.PlayerView>() != null)
                {
                    TargetDetected?.Invoke(hitCollider[i].transform.position);
                }
            }
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
            UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, radius);
        }
#endif

    }
}