using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyTankService : MonoSingletonGeneric<EnemyTankService>
    {

        public EnemyTankScriptableObject[] ConfigEnemyTank;

        public EnemyTankController EnemyTankController { get; private set; }

        public Transform PlayerTransform { get; private set; }

        void Start()
        {
            CreateNewTank();
        }

        private EnemyTankController CreateNewTank()
        {
            int pickRandomTank = Random.Range(0, ConfigEnemyTank.Length);
            EnemyTankScriptableObject enemyTankScriptableObject = ConfigEnemyTank[pickRandomTank];

            //PlayerTransform = TankService.Instance.TankController.TankView.transform;

            EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankScriptableObject);
            EnemyTankController = new EnemyTankController(enemyTankModel, enemyTankScriptableObject.EnemyTankView);

            return EnemyTankController;
        }
    }
}