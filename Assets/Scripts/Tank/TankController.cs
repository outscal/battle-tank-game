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

        public void ApplyDamage( float damage, TankView tank)
        {
           if((TankModel.Health-damage)<= 0)
            {
                TankService.Instance.DestroyView(tank);
            }
            else
            {
                TankModel.Health -= damage;
                TankView.SetTankHealth(TankModel.Health);
                Debug.Log(TankModel.Health);
            }
        }

        public TankView GetTankView()
        {
            return TankView.GetView();
        }

        public TankModel TankModel { get; }
        public TankView TankView { get; }
    }
}
