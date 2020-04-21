using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using BulletSO;

namespace BulletServices
{
    public class BulletService : GenericSingleton<BulletService>
    {
        public BulletScriptableObjectList bulletListScriptableObject;

        public void CreateBullet(Vector3 position, Quaternion rotation, BulletScriptableObject type)
        {
            BulletScriptableObject bullet = type;
            BulletModel bulletModel = new BulletModel(bullet);
            BulletController bulletController = new BulletController(bullet.bulletView, bulletModel, position, rotation);
        }
    }
}
