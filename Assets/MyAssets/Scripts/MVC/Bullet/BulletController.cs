using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Model;
using Bullet.Service;
using Bullet.View;
using System;

namespace Bullet.Controller
{
    public class BulletController
    {
        private Rigidbody rigidBody;
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab, Vector3 position, Quaternion rotation)
        {
            BulletModel = bulletModel;
            BulletView = GameObject.Instantiate<BulletView>(bulletPrefab, position, rotation);

            //BulletView = GameObject.Instantiate<BulletView>(bulletPrefab);
            BulletView.SetBulletController(this);
            BulletModel.SetBulletController(this);
            rigidBody = BulletView.GetComponent<Rigidbody>();
        }

        public void Movement()
        {
            Vector3 move = BulletView.transform.position += BulletView.transform.forward * BulletModel.speed * Time.fixedDeltaTime;

            rigidBody.MovePosition(move);
        }

        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }
    }
}