using TankBattle.Tank.PlayerTank.MoveController;
using UnityEngine;

namespace TankBattle.Tank.CreateTank
{
    public class CreateTankService : GenericSingleton<CreateTankService>
    {
        [SerializeField] private TankTypes.TankScriptableObjectList tankList;
        [SerializeField] private Color tankColor;
        [SerializeField] private Color enemyTankColor;

        private TankController tankController;
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
            tankController = new TankController(tankModel, tankScriptableObject.tankView, enemyTankColor);
            return tankController;
        }

        public TankController CreateNewPlayerTank()
        {
            TankTypes.TankScriptableObject tankScriptableObject = tankList.tanks[0];
            tankModel = new Model.TankModel(tankScriptableObject);
            tankController = new TankController(tankModel, tankScriptableObject.tankView, tankColor);
            return tankController;
        }
    }
}