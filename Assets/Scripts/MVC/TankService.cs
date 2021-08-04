using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattaleTank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public TankView tankView;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            CreatNewTank();
        }

        private TankController CreatNewTank()
        {
            TankModel tankModel = new TankModel(5, 100f);
            TankController tank = new TankController(tankModel, tankView);
            return tank;
        }
    }
}