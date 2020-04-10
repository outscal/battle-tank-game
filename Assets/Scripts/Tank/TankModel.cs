using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Tank
{
    public class TankModel
    {
        public TankModel(int moveingSpeed, int rotatingSpeed, float health, float bulletDamage, Color tankColor)
        {
            MoveingSpeed = moveingSpeed;
            RotatingSpeed = rotatingSpeed;
            Health = health;
            BulletDamage = bulletDamage;
            TankColor = tankColor;
        }

        public int MoveingSpeed { get; }
        public int RotatingSpeed { get; }
        public float Health { get; }
        public float BulletDamage { get; }
        public Color TankColor { get; }
    }
}