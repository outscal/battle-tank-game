using BulletSO;
using EnemySO;
using UnityEngine;

namespace EnemyServices
{
    public class EnemyModel 
    {
        public float health { get; set; }
        public BulletScriptableObject bulletType { get; private set; }
        public BoxCollider ground { get; private set; }
        public float fireRate { get; private set; }

        private EnemyController enemyController;

        public EnemyModel(EnemyScriptableObject enemyScriptableObject)
        {
            health = enemyScriptableObject.health;
            ground = enemyScriptableObject.ground;
            fireRate = enemyScriptableObject.fireRate;
            bulletType = enemyScriptableObject.bulletType;
        }

        public void setEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }

        public void destroyModel()
        {
            bulletType = null;
            enemyController = null;
        }
    }
}
