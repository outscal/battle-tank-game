using BattleTank.camera;
using UnityEngine;

namespace BattleTank.Player
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public float movementSpeed;
        public float rotationSpeed;

        public TankScriptableObject[] ConfigTank;

        void Start()
        {
            CreateNewTank();
        }

        private TankController CreateNewTank()
        {
            int pickRandomTank = Random.Range(0, ConfigTank.Length);
            TankScriptableObject tankScriptableObject = ConfigTank[pickRandomTank];

            TankModel tankModel = new TankModel(tankScriptableObject);
            
            //TankModel tankModel = new TankModel(TankType.None, movementSpeed, rotationSpeed, cam);
            TankController tankController = new TankController(tankModel, tankScriptableObject.TankView);

            return tankController;
        }
    }
}