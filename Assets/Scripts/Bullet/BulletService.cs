using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Event;


namespace TankGame.Bullet
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {

        public BulletScriptableObjectList bulletList;
        public List<BulletController> bullets = new List<BulletController>();
        public BulletView bulletView;
        private Vector3 spawnPos;
        private int bulletCounter=0;

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
                    SetBulletCounter();
                    bullets[i] = null;
                }
            }
        }

        private void SetBulletCounter()
        {
            bulletCounter++;
            if(bulletCounter%100 == 0)
            {
                EventService.Instance.OnBulletAchievment(bulletCounter);
            }
        }

    }
}