using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.ScriptableObjects;

namespace Tank.Model
{
    public class TankModel
    {

        public TankModel(TankScriptableObject tankConfigurations)
        {
            Debug.Log("Tank model created!!!!!!");
            TankType = tankConfigurations.TankType;
            Speed = tankConfigurations.Speed;
        }

        public TankModel(TankType tankType, float speed)
        {
            Debug.Log("Tank model created");
            TankType = tankType;
            Speed = speed;
        }

        public TankType TankType { get; }
        public float Speed { get; }
    }
}