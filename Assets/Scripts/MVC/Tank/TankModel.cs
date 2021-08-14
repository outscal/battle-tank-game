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
        public int Speed { get; private set; }
        public float Health { get; private set; }
        public TankType TankType { get; private set; }

      
        public BulletScriptableObject bulletType { get; private set; }

        public float rotationSpeed { get; private set; }

        public float SpeedLive { get { return tankScriptableObject.Speed; } }
        private TankScriptableObject tankScriptableObject;
        private TankController tankController;
        public float fireRate { get; private set; }

        public TankModel(TankScriptableObject tankScriptableObject)
        {
            this.tankScriptableObject = tankScriptableObject;
            TankType = tankScriptableObject.TankType;
            Speed = (int)tankScriptableObject.Speed;
            Health = tankScriptableObject.Health;
            rotationSpeed = tankScriptableObject.rotationSpeed;
            fireRate = tankScriptableObject.fireRate;
            bulletType = tankScriptableObject.bulletType;
        }
        public TankModel(TankType tankType, int speed, float health)
        {
            TankType = tankType;
            Speed = speed;
            Health = health;
        }

        //setting tenk controller
        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }
       
    }
}