using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        private int health = 5;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int score = 0;
        private float speed = 3f;

        public float Speed
        {
            get { return speed; }
        }

        private float rotationSpeed = 4f;

        public float RotationSpeed
        {
            get { return rotationSpeed; }
        }

        private bool isPlayer = true;

        public bool IsPlayer
        {
            get { return isPlayer; }
        }

        private float fireRate = 0.24f;

        public float FireRate
        {
            get { return fireRate; }
        }

    }
}