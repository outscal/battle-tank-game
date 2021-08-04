using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattaleTank
{
    public class TankModel
    {
        public TankModel(int speed, float health)
        {
            Speed = speed;
            Health = health;
            //speed health and all behavious will define here
        }

        public int Speed { get; private set; }
        public float Health { get; private set; }
    }
}