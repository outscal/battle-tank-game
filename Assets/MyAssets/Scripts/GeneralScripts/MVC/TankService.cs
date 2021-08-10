using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattaleTank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public ScriptableObjectList tankListSO;

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
            int randomNo = Random.Range(0, tankListSO.tank.Length);
            TankScriptableObjects tankScriptableObjects = tankListSO.tank[randomNo];
            TankView tankView = tankScriptableObjects.tankView;
            TankModel tankModel = new TankModel(tankScriptableObjects);
            TankController tank = new TankController(tankModel, tankView);

            return tank;
        }
    }
}