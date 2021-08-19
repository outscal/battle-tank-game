using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// bullet model class
    /// </summary>
    public class BulletModel
    {
        public float BulletForce { get; private set; }
        public int Damage { get; private set; }
        public BulletType Type { get; private set; }
        public BulletController bulletController { get; private set; }

        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            //this.bulletScriptableObject = bulletScriptableObject;
            BulletForce = bulletScriptableObject.bulletForce;           
            Damage = bulletScriptableObject.bulletDamage;
            Type = bulletScriptableObject.bulletType;
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }
    }
}