using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT USED FOR COMMUNICATION

namespace PlayerTankService
{
    public class TankService : MonoSingletonGeneric <TankService>
    {
        public TankView tankView;
        public TankScriptableObjectList tankList;
        private void Start()
        {
            StartGame();
        }
        public void StartGame()
        {
            for (int i = 0; i < 3; i++)
            {
                CreateNewTank();
            }
        }
        private TankController CreateNewTank()
        {
            TankScriptableObject tankScriptableObject = tankList.tanks[2];
            TankModel model = new TankModel(tankScriptableObject);
            TankController tank = new TankController(model, tankView);
            return tank;
        }
    }
}
