using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// this class handles the tank model
    /// </summary>
    public class TankModel
    {
        public TankModel(int speed, float health)
        {
            Speed = speed;
            Health = health;
        }

        public int Speed { get; }
        public float Health { get; }
    }
}