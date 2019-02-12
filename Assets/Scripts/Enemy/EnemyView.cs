using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Interfaces;
using System;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyView : MonoBehaviour, ITakeDamage
    {
        private EnemyController enemyController;

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

        public int DamageValue()
        {
            return enemyController.enemyModel.scriptableObj.damage;
        }

        public void TakeDamage(int damage)
        {
            enemyController.TakeDamage(damage);
        }
    }
}