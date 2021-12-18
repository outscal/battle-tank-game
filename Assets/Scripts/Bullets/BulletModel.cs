using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletSO;

namespace BulletServices
{
    public class BulletModel
    {
        public float Speed { get; private set; }
        public float Damage { get; private set; }
        public BulletType bulletType;
        private BulletController bulletController;

        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            Speed = bulletScriptableObject.speed;
            Damage = bulletScriptableObject.damage;
            bulletType = bulletScriptableObject.bulletType;
        }

        public void SetBulletController(BulletController bulletController)
        {
            this.bulletController = bulletController;
        }

    }
}
