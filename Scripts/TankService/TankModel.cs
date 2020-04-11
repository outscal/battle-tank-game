using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TankServices
{
    //this class is responsilbe to take care of data...
    public class TankModel
    {
        private TankController tankController;

        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }
        public float fireRate { get; private set; }
        public float Health { get; private set; }

        public void SetMovementParameters(float _movementSpeed, float _rotationSpeed)
        {
            movementSpeed = _movementSpeed;
            rotationSpeed = _rotationSpeed;
        }

        public void SetHealthParameters(float health)
        {
            Health = health;
        }

        public void SetShootingParameters(float _fireRate)
        {
            fireRate = _fireRate;
        }

        public void GetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

    }
}