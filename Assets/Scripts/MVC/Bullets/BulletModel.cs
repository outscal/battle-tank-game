using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    public class BulletModel
    {
        private BulletController bulletController;
        private BulletScriptableObject bulletScriptableObject;
        public BulletType BulletType { get; private set; }
        public int Speed { get; private set; }
        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            this.bulletScriptableObject = bulletScriptableObject;
            BulletType = bulletScriptableObject.BulletType;
            Speed = bulletScriptableObject.Speed;
        }       
    }
}