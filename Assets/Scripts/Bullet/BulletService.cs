using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TankGame.Bullet
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {

        public BulletScriptableObjectList bulletList;
        public List<BulletController> bullets = new List<BulletController>();
        public BulletView bulletView;
        private Vector3 spawnPos;

        protected override void Awake()
        {
            base.Awake();
        }

        public BulletController spawnBullet(Transform bulletSpawner, float bulletDamage)
        {
            BulletModel bulletModel = new BulletModel(bulletList.bulletScriptableObject[0]);
            BulletController bullet = new BulletController(bulletModel, bulletView, bulletSpawner, bulletDamage);
            bullets.Add(bullet);
            return bullet;
        }

        public void DestroyView(BulletController controller)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if(controller == bullets[i])
                {
                    controller.Destroy();
                }
            }
        }
    }
}