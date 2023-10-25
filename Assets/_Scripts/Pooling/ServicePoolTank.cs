using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BattleTank
{
    public class ServicePoolTank : ServicePool<TankController>
    {
        private TankView tankPrefab;
        private TankModel tankModel;

        public TankController GetTank(TankModel tankModel, TankView tankPrefab)
        {
            this.tankModel = tankModel;
            this.tankPrefab = tankPrefab;
            return GetItem();
        }

        protected override TankController CreateItem()
        {
            TankController tankController = new TankController(tankModel, tankPrefab);
            return tankController;
        }
    }
}