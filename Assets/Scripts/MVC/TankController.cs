using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattaleTank
{
    public class TankController
    {
        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            TankModel = tankModel;
            TankView go = GameObject.Instantiate<TankView>(tankPrefab);
        }

        public TankModel TankModel { get; private set; }
    }
}