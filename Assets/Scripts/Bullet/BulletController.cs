using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public void ApplyDamage()
        {
           
        }

        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }
    }
}