using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Bullet
{
    public class BulletController
    {
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform spawner)
        {
            BulletModel = bulletModel;
            Vector3 newPos = spawner.transform.position;

            BulletPrefab = GameObject.Instantiate(bulletPrefab, spawner.transform.position, spawner.transform.rotation);
            Rigidbody rb = BulletPrefab.GetComponent<Rigidbody>();
            rb.velocity = spawner.transform.forward * BulletModel.Speed;
            //bulletPrefab.SetBulletDetails(BulletModel, spawner.transform.position);
            Debug.Log("controller speed" + BulletModel.Speed);
            
        }

        public BulletModel BulletModel { get; }
        public BulletView BulletPrefab { get; }
    }
}