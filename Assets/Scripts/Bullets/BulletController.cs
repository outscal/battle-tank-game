using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletServices
{
    public class BulletController
    {
        public BulletModel bulletModel { get; private set; }
        public BulletView bulletView { get; private set; }
        private Rigidbody rb;

        public BulletController(BulletModel model, BulletView bulletView, Vector3 position, Quaternion rotation)
        {
            bulletModel = model;
            bulletView = GameObject.Instantiate<BulletView>(bulletView, position, rotation);
            rb = bulletView.GetComponent<Rigidbody>();
            bulletView.SetBulletController(this);
            bulletModel.SetBulletController(this);
        }
    }
}
