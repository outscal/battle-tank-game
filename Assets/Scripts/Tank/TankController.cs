using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Bullet;

namespace TankGame.Tank
{
    public class TankController
    {
        public TankController(TankModel tankModel, TankView tankPrefab, Transform spawner)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab, spawner.transform.position, spawner.transform.rotation);
            TankView.SetViewDetails(tankModel);
            TankView.InitialiseController(this);
        }

        public void fire(Transform bulletSpawn, float bulletDamange)
        {
            BulletService.Instance.spawnBullet(bulletSpawn, bulletDamange);
        }

        public void TakeDamage(TankView tank, float damage)
        {
            tank.ApplyPlayerTankDamage(damage);
        }

        public void DestroyTankView(TankView tankView)
        {
            TankService.Instance.DestroyView(tankView);
        }

        public TankModel TankModel { get; }
        public TankView TankView { get; }
    }
}
