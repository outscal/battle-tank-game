using UnityEngine;

namespace TankBattle.TankService
{

    // Main Service - create/ instantiate a new tank with tankController component reference
    // Rename to CreateTankService - or TankSpawner
    // Namespace: TankBattle.CreateTankService :: current
    // or should it be TankBattle.Tank.Service.Create


    public class TankService : GenericSingleton<TankService>
    {
        [SerializeField] private TankType.TankScriptableObjectList tankList;

        private int enemyTankIndex;

        // might not be required in tankService
        private PlayerTank.MoveService.TankController tankController;
        private TankModel tankModel;

        // not needed if not doing anything on awake
        protected override void Awake()
        {
            base.Awake();
            enemyTankIndex = tankList.tanks.Length - 1;
        }

        // creating enemy tank in a fixed location
        // directly accessing transform.position of game object

        public void CreateEnemyTank(Vector3 spawnPoint)
        {
            TankType.TankScriptableObject tankScriptableObject = tankList.tanks[enemyTankIndex];
            tankScriptableObject.tankView.transform.position = spawnPoint;
            tankModel = new TankModel(tankScriptableObject);
            tankController = new PlayerTank.MoveService.TankController(tankModel, tankScriptableObject.tankView);
        }

        public PlayerTank.MoveService.TankController CreateNewPlayerTank(int index)
        {
            TankType.TankScriptableObject tankScriptableObject = tankList.tanks[index];
            tankModel = new TankModel(tankScriptableObject);
            tankController = new PlayerTank.MoveService.TankController(tankModel, tankScriptableObject.tankView);
            return tankController;
        }
    }
}