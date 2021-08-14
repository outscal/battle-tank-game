using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    public class BulletModel
    {
        //private BulletController bulletController;
        //private BulletScriptableObject bulletScriptableObject;
        //public BulletType BulletType { get; private set; }
        //public int Speed { get; private set; }

        //public BulletModel(BulletScriptableObject bulletScriptableObject)
        //{
        //    this.bulletScriptableObject = bulletScriptableObject;
        //    BulletType = bulletScriptableObject.BulletType;
        //    Speed = bulletScriptableObject.Speed;
        //}     

        //public void SetBulletController(BulletController _bulletController)
        //{
        //    bulletController = _bulletController;
        //}

        public float bulletForce { get; private set; }
        public float damage { get; private set; }
        public BulletType type;
        private BulletController bulletController;
        public BulletModel(BulletScriptableObject bulletSO)
        {
            type = bulletSO.bulletType;
            bulletForce = bulletSO.bulletForce;
            damage = bulletSO.bulletDamage;           
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }
    }
}