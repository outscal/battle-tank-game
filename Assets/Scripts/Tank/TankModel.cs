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

        public TankModel()
        {
            //Later we will assign different values for each tank
            speed = 0.5f;
            health = 100;
            turningTorque = 1.0f;
            tankType = TankType.BlueTank;
        }
    }
}
