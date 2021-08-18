using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// service class that handles all tank services
    /// and it inherits Monobehaviour class
    /// </summary>
    public class TankService : MonoGenericSingletone<TankService>
    {
        public TankScriptableObjectList tankList;
        public TankScriptableObject TankScriptableObject { get; private set; }
        public TankView TankView { get; private set; }

        public Transform pos;
        int randomNo;
        private void Start()
        {
            StartGame();
        }

        void StartGame()
        {
            CreateNewTank();
        }
        private TankController CreateNewTank()
        {
            randomNo = Random.Range(0, tankList.tanks.Length);
            TankScriptableObject tankScriptableObject = tankList.tanks[randomNo];
            TankView = tankScriptableObject.TankView;
            TankModel tankModel = new TankModel(tankScriptableObject);
            TankController tank = new TankController(tankModel, TankView);
            return tank;
        }

        public void GetPlayerPos(Transform _position)
        {
            pos = _position;
        }

        public Transform PlayerPos()
        {
            return pos;
        }

    }
}