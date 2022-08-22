using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankScriptableObjects;

namespace TankServices {
    public class TankModel
    {
        private TankController tankController;

        // TankModel -> controller
        public void SetTankControllerReference(TankController _tankController)
        {
            tankController = _tankController;
        }

        public TankModel(TankScriptableObject tankScriptableObject)
        {
            TankType = tankScriptableObject.tankType;
            RotationSpeed = tankScriptableObject.rotationSpeed;
            MovementSpeed = tankScriptableObject.speed;
            Health = tankScriptableObject.health;
            RotationSpeed = tankScriptableObject.rotationSpeed;
            TankColor = tankScriptableObject.tankColor;
        }

        public float MovementSpeed { get; }
        public TankType TankType { get; }
        public int Health { get; set; }
        public float RotationSpeed { get; }
        public Color TankColor { get; set; }
    }
}
