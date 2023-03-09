using TankBattle.Tank.PlayerTank.MoveController;
using UnityEngine;

namespace TankBattle.Tank.CreateTank
{
    public class CreateTankService : GenericSingleton<CreateTankService>
    {
        [SerializeField] private TankTypes.TankScriptableObjectList tankList;
        private Model.TankModel tankModel;

        protected override void Awake()
        {
            base.Awake();
        }

        public TankController CreateEnemyTank(Vector3 spawnPoint)
        {
            TankTypes.TankScriptableObject tankScriptableObject = tankList.tanks[1];
            tankScriptableObject.tankView.transform.position = spawnPoint;
            tankModel = new Model.TankModel(tankScriptableObject);
            TankController tankController = new TankController(tankModel, tankScriptableObject.tankView);
            return tankController;
        }

        public TankController CreateNewPlayerTank()
        {
            TankTypes.TankScriptableObject tankScriptableObject = tankList.tanks[0];
            tankModel = new Model.TankModel(tankScriptableObject);
            TankController tankController = new TankController(tankModel, tankScriptableObject.tankView);
            return tankController;
        }

        public TankController CreateNewPlayerTank(Vector3 SpawnPosition)
        {
            TankTypes.TankScriptableObject tankScriptableObject = tankList.tanks[0];
            tankModel = new Model.TankModel(tankScriptableObject);
            TankController tankController = new TankController(tankModel, tankScriptableObject.tankView, SpawnPosition);
            return tankController;
        }
    }
}