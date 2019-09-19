using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public class TankModel
    {
        private float speed;
        public float Speed {get {return speed; }}
        private float shootingRange;
        public float ShootingRange {get{ return shootingRange; }}
        private float enemyDetectionRange;
        public float EnemyDetectionRange {get{ return enemyDetectionRange; }}
        private float turningTorque;
        public float TurningTorque {get{ return turningTorque; }}
        public int Health {get; set;}
        private TankType tankType;
        private TankView tankPrefab;
        public TankView TankPrefab{get{return tankPrefab; }}
        public int Kills{get; set;}

        public TankModel(TankScriptableObject _tankScriptableObject)
        {
            speed = _tankScriptableObject.speed;
            Health = _tankScriptableObject.health;
            turningTorque = _tankScriptableObject.turningTorque;
            tankType = _tankScriptableObject.tankType;
            tankPrefab = _tankScriptableObject.tankPrefab;
            shootingRange = _tankScriptableObject.shootingRange;
            enemyDetectionRange = _tankScriptableObject.enemyDetectionRadius;
            Kills = 0;
        }
    }
}
