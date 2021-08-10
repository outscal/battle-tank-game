using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankModel
    {

        private TankController tankController;
        public TankType tankType { get; private set; }
        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }
        public float fireRate { get; private set; }
        public float health { get; set; }
        public BulletScriptableObjects bulletType { get; private set; }
        public TankModel(TankScriptableObjects tankSO)
        {

            //type
            tankType = tankSO.tankType;

            // behaviour vars
            movementSpeed = tankSO.movementSpeed;
            rotationSpeed = tankSO.rotationSpeed;
            fireRate = tankSO.fireRate;
            health = tankSO.health;
        }

        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

    }//class


}



// private TankController tankController;
// public TankType TankType { get; private set; }
// public float movementSpeed { get; private set; }
// public float roatationSpeed { get; private set; }
// public float Health { get; private set; }


// public TankModel(TankScriptableObjects tankScriptableObjects)
// {
//     TankType = tankScriptableObjects.tankType;
//     movementSpeed = tankScriptableObjects.movementSpeed;
//     roatationSpeed = tankScriptableObjects.rotationSpeed;
//     Health = tankScriptableObjects.health;

// }

// public void SetTankController(TankController _tankController)
// {
//     tankController = _tankController;
// }

// public TankModel(float movSpeed, float rotSpeed, float health)
// {
//     movementSpeed = movSpeed;
//     roatationSpeed = rotSpeed;
//     Health = health;
// }