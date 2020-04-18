using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Tank
{
    public class TankModel
    {
        public TankModel(TankScriptableObject tank)
        {
            MovingSpeed = tank.movingSpeed;
            RotatingSpeed = tank.rotatingSpeed;
            Health = tank.health;
            BulletDamage = tank.damage;
            TankColor = tank.tankColor;
        }

        public int MovingSpeed { get; }
        public int RotatingSpeed { get; }
        public float Health { get; set; }
        public float BulletDamage { get; }
        public Color TankColor { get; }
    }
}