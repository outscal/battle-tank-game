using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        private List<BulletController> bullets = new List<BulletController>();
        public void CreateBullet(Vector3 position, Quaternion rotation, BulletScriptableObjects type)
        {
            BulletScriptableObjects bullet = type;
            BulletModel bulletModel = new BulletModel(bullet);
            BulletController bulletController = new BulletController(bullet.bulletView, bulletModel, position, rotation);
            bullets.Add(bulletController);
        }

    }
}