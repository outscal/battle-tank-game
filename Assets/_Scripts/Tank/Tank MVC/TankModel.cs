//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
using Tank.ScriptableObjects;
//using System;

namespace Tank.Model
{
    public class TankModel
    {
        public PlayerTankType TankType { get; private set; }
        public float Speed { get; private set; }

        public TankModel(TankScriptableObject tankConfigurations)
        {
            TankType = tankConfigurations.TankType;
            Speed = tankConfigurations.Speed;
        }

        public TankModel(PlayerTankType tankType, float speed)
        {
            TankType = tankType;
            Speed = speed;
        }

        public void ClearUpAllYourData()
        {
            //clear up all the data
        }
    }
}