using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class TankModel
    {
        public float speed;

        public float turningTorque;
        public int health;
        public TankType tankType;
        public TankView tankPrefab;

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
