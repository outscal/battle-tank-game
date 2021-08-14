using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        [SerializeField]
        private TankScriptableObjectList tanks;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            CreateNewTank();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CreateNewTank();
            }
        }

        private void CreateNewTank()
        {
            TankScriptableObject tankScriptableObject;
            tankScriptableObject = tanks.tankList[Random.Range(0, 2)];
            TankModel model = new TankModel(tankScriptableObject);
            TankController tank = new TankController(model, tankScriptableObject.TankView);
        }
    }
}


