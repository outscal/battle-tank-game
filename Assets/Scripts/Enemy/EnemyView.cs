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

        private int health;

        public void SetEnemyController(EnemyController enemyController)
        {
            this.enemyController = enemyController;
        }

        public void setHealth(int health)
        {
            this.health = health;
        }

        public void DamageEnemy(int value)
        {
            health -= value;
            Debug.Log("[EnemyView] Value: " + value + " Health: " + health);
            if(health <= 0)
            {
                DestroyEnemy();
            }
        }

        public void DestroyEnemy()
        {
            GameUI.Instance.UpdatePlayerScore(enemyController.enemyModel.scriptableObj.scoreIncrease);
            EnemyManager.Instance.DestroyEnemy(enemyController);
            Destroy(gameObject);
        }

        public int DamageValue()
        {
            return enemyController.enemyModel.scriptableObj.damage;
        }
    }
}