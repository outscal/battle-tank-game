using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTank
{
    public class TankModel
    {
        private TankController tankController;

        private TankTypeScriptableObject tankTypeScriptableObject;

        public TankType TankType { get; }
        public float Speed { get; }
        public int Health { get; }

        public Material tankMaterial;
       

        public int SpeedLive { get { return (int)tankTypeScriptableObject.speed; } }
        public TankModel(TankTypeScriptableObject tankTypeScriptableObject)
        {
            this.tankTypeScriptableObject = tankTypeScriptableObject;
            TankType = tankTypeScriptableObject.tankType;
            Speed = tankTypeScriptableObject.speed;
            Health = tankTypeScriptableObject.maxhealth;
            tankMaterial = tankTypeScriptableObject.color;
          
        }


        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }
    }
}