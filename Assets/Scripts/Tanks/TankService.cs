using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletServices;
using TankSO;

namespace TankServices
{
    public class TankService : SingletonGeneric<TankService>
    {
        public ScriptableObjectList tankList;
        public TankView tankView;

        public BulletService BulletService { get; private set; }

        private void Start()
        {
            CreateNewTank();
        }

        public void GetBulletService()
        {
            BulletService = BulletService.GetComponent<BulletService>();
        }

        private TankController CreateNewTank()
        {
            int random = Random.Range(0, tankList.tank.Length - 1);
            TankScriptableObjects tankScriptableObjects = tankList.tank[random];
            TankModel tankModel = new TankModel(tankScriptableObjects);
            TankController tank = new TankController(tankModel, tankView);
            return tank;
        }
    }
}