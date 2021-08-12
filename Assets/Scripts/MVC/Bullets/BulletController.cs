using System;
using UnityEngine;

namespace Outscal.BattleTank
{
    public class BulletController 
    {
        private Rigidbody rigidbody;

        public BulletModel BulletModel { get; private set; }
        public BulletView BulletView { get; private set; }
        public BulletController(BulletModel bulletModel,BulletView bulletPrefab)
        {
            BulletModel = bulletModel;
            BulletView = GameObject.Instantiate<BulletView>(bulletPrefab);
            rigidbody = BulletView.GetComponent<Rigidbody>();
            
            Debug.Log("bullet prefab instantiated");
            BulletModel = bulletModel;
            BulletView = bulletPrefab;
        }     
    }
}