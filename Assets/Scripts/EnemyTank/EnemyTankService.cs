using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyTankService : MonoBehaviour
    {

        public EnemyTankScriptableObject[] ConfigEnemyTank;

        public EnemyTankController EnemyTankController { get; private set; }

        void Start()
        {
            CreateNewTank();
        }

        private EnemyTankController CreateNewTank()
        {
            int pickRandomTank = Random.Range(0, ConfigEnemyTank.Length);
            EnemyTankScriptableObject enemyTankScriptableObject = ConfigEnemyTank[pickRandomTank];

            EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankScriptableObject);
            EnemyTankController = new EnemyTankController(enemyTankModel, enemyTankScriptableObject.EnemyTankView);

            return EnemyTankController;
        }
    }
}