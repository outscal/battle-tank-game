using TankBattle.Tank.PlayerTank.MoveController;
using UnityEngine;

namespace TankBattle.Tank.CreateTank
{
    public class CreateTankService : GenericSingleton<CreateTankService>
    {
        [SerializeField] private TankTypes.TankScriptableObjectList tankList;
        private Model.TankModel tankModel;

        public TankController CreateTank(Vector3 spawnPoint, int tankTypeIndex)
        {
            TankTypes.TankScriptableObject tankScriptableObject = tankList.tanks[tankTypeIndex];
            tankModel = new Model.TankModel(tankScriptableObject);
            TankController tankController = new TankController(tankModel, tankScriptableObject.tankView, spawnPoint);
            tankController.GetTankView.SetTankController(tankController);
            tankController.GetTankView.SetMaxHealth(tankModel.GetSetHealth);
            tankController.GetTankView.SetHealthUI();
            return tankController;
        }
    }
}