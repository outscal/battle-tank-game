using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Service;
using Bullet.Controller;
using Bullet.View;

namespace Bullet.Model
{
    public class BulletModel
    {
        public BulletModel(float damage)
        {
            Damage = damage;
        }

        public float Damage { get; }
    }
}