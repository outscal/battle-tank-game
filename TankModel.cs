using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankModel
    {
        public TankModel(TankScriptableObject tankScriptableObject)
        {
            Speed = tankScriptableObject.Speed;
            Health = tankScriptableObject.Health;
        }

        public float Speed { get; }
        public float Health { get; }
    }
}
