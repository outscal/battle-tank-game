using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic;
using ScriptableObj;

namespace Bullet
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        public Transform BulletParent;
        public List<BulletScriptableObj> BulletConfigurations;

        private List<BulletController> Bullets = new List<BulletController>();


        protected override void Awake()
        {
            base.Awake();
        }


        public BulletController GetBullet(Transform bulletTransform, float tankDamageBooster)
        {
            BulletModel bulletmodel = new BulletModel(bulletTransform, tankDamageBooster, BulletConfigurations[0]);
            BulletController bulletController = new BulletController(bulletmodel, bulletmodel.BulletView, BulletParent);
            Bullets.Add(bulletController);
            return bulletController;
        }


        public void DestroyBullet(BulletController bullet)
        {
            bullet.KillController();
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i] == bullet)
                {
                    Bullets.Remove(Bullets[i]);
                    break;
                }
            }
            bullet = null;
        }

    }
}
