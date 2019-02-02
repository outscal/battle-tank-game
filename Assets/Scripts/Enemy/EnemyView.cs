using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyView : MonoBehaviour
    {

        private EnemyController enemyController;

        public void SetEnemyController(EnemyController enemyController)
        {
            this.enemyController = enemyController;
        }

        public void DamageEnemy(int value)
        {
            enemyController.TakeDamage(value);
        }

        public void DestroyEnemy()
        {
            //playerController.setPlayerScore(enemyController.getScoreIncreaser());
            GameUI.InstanceClass.UpdatePlayerScore(enemyController.getScoreIncreaser());
            EnemyManager.Instance.DestroyEnemy(enemyController);
            Destroy(gameObject);
        }

        public int DamageValue()
        {
            return enemyController.enemyModel.scriptableObj.damage;
        }
    }
}