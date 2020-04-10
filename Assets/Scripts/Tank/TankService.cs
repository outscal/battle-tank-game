using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Bullet;

namespace TankGame.Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public TankView tankView;
        public Color[] tankColor;
        public float[] tankHealth;
        public float[] bulletDamage;

        protected override void Awake()
        {
            base.Awake();
        }

        public void fire(Transform bulletSpawn, float bulletDamange)
        {
            BulletService.Instance.spawnBullet(bulletSpawn, bulletDamange);
        }

        public void SpawnTankPrefab(Transform spawner, int tankSerial)
        {
            TankModel model = new TankModel(250, 100, tankHealth[tankSerial], bulletDamage[tankSerial], tankColor[tankSerial]);
            TankController tank = new TankController(model, tankView, spawner);
        }
    }
}