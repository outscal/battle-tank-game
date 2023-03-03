using UnityEngine;

namespace TankBattle.TankService
{

    // Main Service - create/ instantiate a new tank with tankController component reference
    // Rename to CreateTankService - 
    // Namespace: TankBattle.CreateTankService


    public class TankService : GenericSingleton<TankService>
    {
        [SerializeField] private TankView tankView;
        [SerializeField] private TankType.TankScriptableObjectList tankList;

        // might not be required in tankService
        private PlayerTank.MoveService.TankController tankController;
        private TankModel tankModel;

        // not needed if not doing anything on awake
        protected override void Awake()
        {
            base.Awake();
        }

        private Color getColorValue(int index)
        {             
            if (index == (int)TankType.TankType.None)
            {
                return Color.black;
            }
            if (index == (int)TankType.TankType.Red)
            {
                return Color.red;
            }
            if (index == (int)TankType.TankType.Green)
            {
                return Color.green;
            }
            if (index == (int)TankType.TankType.Blue)
            {
                return Color.blue;
            } 
             return Color.white;
        }

        public PlayerTank.MoveService.TankController CreateNewPlayerTank(int index)
        {
            TankType.TankScriptableObject tankScriptableObject = tankList.tanks[index];
            tankModel = new TankModel(tankScriptableObject);
            Color color = getColorValue(index);
            tankController = new PlayerTank.MoveService.TankController(tankModel, tankView);
            return tankController;
        }
    }
}