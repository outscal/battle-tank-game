using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public TankScriptableObject[] ConfigTank;

        public TankController TankController { get; private set; }

        void Start()
        {
            CreateNewTank();
        }

        private TankController CreateNewTank()
        {
            int pickRandomTank = Random.Range(0, ConfigTank.Length);
            TankScriptableObject tankScriptableObject = ConfigTank[pickRandomTank];

            TankModel tankModel = new TankModel(tankScriptableObject);
            TankController = new TankController(tankModel, tankScriptableObject.TankView);

            return TankController;
        }
    }
}