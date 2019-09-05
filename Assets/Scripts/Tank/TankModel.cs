using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class TankModel
    {
        private float speed;
        public float Speed {get {return speed;}}
        private float turningTorque;
        public float TurningTorque {get{ return turningTorque;}}
        private int health;
        public int Health {get{ return health;} set{health = value;}}
        private TankType tankType;
        private TankView tankPrefab;
        public TankView TankPrefab{get{return tankPrefab;}}

        public TankModel(TankScriptableObject _tankScriptableObject)
        {
            speed = _tankScriptableObject.speed;
            health = _tankScriptableObject.health;
            turningTorque = _tankScriptableObject.turningTorque;
            tankType = _tankScriptableObject.tankType;
            tankPrefab = _tankScriptableObject.tankPrefab;
        }
    }
}
