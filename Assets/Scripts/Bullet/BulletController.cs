using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Tank;
using TankGame.Enemy;

namespace TankGame.Bullet
{
    public class BulletController
    {
        public BulletController(BulletModel bulletModel, BulletView bulletView, Transform spawner, float damageValue)
        {
            BulletModel = bulletModel;
            Vector3 newPos = spawner.transform.position;
            
            BulletView = GameObject.Instantiate(bulletView, spawner.transform.position, spawner.transform.rotation);
            Rigidbody rb = BulletView.GetComponent<Rigidbody>();
            rb.velocity = spawner.transform.forward * BulletModel.Speed;

            BulletView.SetBulletDetails(BulletModel, damageValue);
            BulletView.InitializeController(this);
        }

        public void DestroyBulletView(BulletView bullet)
        {
            BulletService.Instance.DestroyView(bullet);
        }

        //public void ApplyEnemyDamage(float damage, EnemyView enemyTank)
        //{
        //    HealthService.Instance.DeductEnemyHealth( enemyTank, damage);
        //}

        //public void ApplyPlayerDamage(float damage, TankView playerTank)
        //{
        //    HealthService.Instance.DeductPlayerHealth( playerTank, damage);
        //}

        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }
    }
}