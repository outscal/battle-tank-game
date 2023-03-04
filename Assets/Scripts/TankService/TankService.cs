using UnityEngine;

namespace TankBattle.TankService
{

    // Main Service - create/ instantiate a new tank with tankController component reference
    // Rename to CreateTankService - 
    // Namespace: TankBattle.CreateTankService


    public class TankService : GenericSingleton<TankService>
    {
        [SerializeField] private TankType.TankScriptableObjectList tankList;

        private int enemyTankListVal = 4;

        // might not be required in tankService
        private PlayerTank.MoveService.TankController tankController;
        private TankModel tankModel;

        // not needed if not doing anything on awake
        protected override void Awake()
        {
            base.Awake();
        }

        // temporary function  creating in a new place

        public void CreateEnemyTank(Vector3 spawnPoint)
        {
            TankType.TankScriptableObject tankScriptableObject = tankList.tanks[enemyTankListVal];
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