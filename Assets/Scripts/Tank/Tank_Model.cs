using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class Tank_Model
    {
        public string TankName { get; }
        public Tank_Types TankType { get; }
        public int Speed { get; }
        public float Health { get; }
        public float RotationSpeed { get; }
        public Tank_Model(Tank_ScriptableObject tank_ScriptableObject)
        {
            TankType = tank_ScriptableObject.TankType;
            Speed = tank_ScriptableObject.Speed;
            Health = tank_ScriptableObject.Health;
            TankName = tank_ScriptableObject.TankName;
            RotationSpeed = tank_ScriptableObject.RotationSpeed;
        }
    }
}
