using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TankSO;

namespace TankServices
{
    //this class is responsilbe to take care of data...
    public class TankModel
    {
        private TankController tankController;

        public TankType tankType { get; private set; }
        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }
        public float fireRate { get; private set; }
        public float health { get; private set; }
        public Material redMat { get; private set; }
        public Material blueMat { get; private set; }
        public Material greenMat { get; private set; }

        public TankModel(TankScriptableObject tankScriptable, TankScriptableObjectList tankList)
        {
            //type
            tankType = tankScriptable.tankType;

            // behaviour vars
            movementSpeed = tankScriptable.movementSpeed;
            rotationSpeed = tankScriptable.rotationSpeed;
            fireRate = tankScriptable.fireRate;
            health = tankScriptable.health;

            //colors
            redMat = tankList.redMat;
            blueMat = tankList.blueMat;
            greenMat = tankList.greenMat;
        }
        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }
    }
}