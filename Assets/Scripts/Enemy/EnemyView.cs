using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public void DestroyEnemy()
        {
            EnemyManager.Instance.DestroyEnemy(enemyController);
            Destroy(gameObject);
        }
    }
}