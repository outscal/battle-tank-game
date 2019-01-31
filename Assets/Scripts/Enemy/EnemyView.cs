using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if(value <= 0)
            {
                DestroyEnemy();
            }
        }

        public void DestroyEnemy()
        {
            EnemyManager.Instance.DestroyEnemy(enemyController);
            Destroy(gameObject);
        }
    }
}