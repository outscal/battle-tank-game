using Singleton;
using UnityEngine;
using Tank;

namespace Enemy
{
    public class EnemySpawnerService : MonoSingletonGeneric<EnemySpawnerService>
    {
        [SerializeField]
        private GameObject enemyTankPrefab;

        public TankController CreateEnemy()
        {
            GameObject tankGameObject = GameObject.Instantiate(enemyTankPrefab);
            TankController tankControl = tankGameObject.GetComponent<TankController>();
            return tankControl;
        }
    }
}
