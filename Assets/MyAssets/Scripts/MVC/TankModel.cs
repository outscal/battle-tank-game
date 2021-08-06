using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattaleTank
{
    public class TankModel
    {

        private TankController tankController;
        public TankModel(TankScriptableObjects tankScriptableObjects)
        {
            TankType = tankScriptableObjects.tankType;
            movementSpeed = (int)tankScriptableObjects.movementSpeed;
            roatationSpeed = (int)tankScriptableObjects.rotationSpeed;
            Health = tankScriptableObjects.health;

        }
        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }



        public TankModel(float movSpeed, float rotSpeed, float health)
        {
            movementSpeed = movSpeed;
            roatationSpeed = rotSpeed;
            Health = health;
        }

        public TankType TankType { get; private set; }
        public float movementSpeed { get; private set; }
        public float roatationSpeed { get; private set; }
        public float Health { get; private set; }
    }
}