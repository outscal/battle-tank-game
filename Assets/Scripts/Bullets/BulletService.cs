using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankServices;
using BulletSO;

namespace BulletServices
{
    public class BulletService : SingletonGeneric<BulletService>
    {
        public BulletScriptableObjectList bulletList;
        public BulletView bulletView;
        public TankService tankService { get; private set; }

        public void CreateBullet(Vector3 position, Quaternion rotation, BulletScriptableObject bulletType)
        {
            BulletScriptableObject type = bulletType;
            BulletModel bulletModel = new BulletModel(type);
            BulletController bulletController = new BulletController(bulletModel, bulletView, position, rotation);
        }
    }
}
