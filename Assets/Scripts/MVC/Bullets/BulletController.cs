using System;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// bullet control logics
    /// </summary>
    public class BulletController 
    {
        //private Rigidbody rigidbody;

        //public BulletModel BulletModel { get; private set; }
        //public BulletView BulletView { get; private set; }
        //public static object BulletType { get; internal set; }

        //public BulletController(BulletModel bulletModel,BulletView bulletPrefab)
        //{
        //    BulletModel = bulletModel;
        //    BulletView = GameObject.Instantiate<BulletView>(bulletPrefab);
        //    rigidbody = BulletView.GetComponent<Rigidbody>();

        //    Debug.Log("bullet prefab instantiated");
        //    BulletModel = bulletModel;
        //    BulletView = bulletPrefab;
        //    BulletView.SetBulletController(this);
        //    BulletModel.SetBulletController(this);
        //}     

        public BulletView bulletView { get; private set; }
        public BulletModel bulletModel { get; private set; }
        private Rigidbody rigidbody;

        public BulletController(BulletView _bulletView, BulletModel _bulletModel, Vector3 position, Quaternion rotation)
        {
            bulletModel = _bulletModel;
            bulletView = GameObject.Instantiate<BulletView>(_bulletView, position, rotation);
            bulletView.SetBulletController(this);
            bulletModel.SetBulletController(this);
            rigidbody = bulletView.GetComponent<Rigidbody>();
        }

        //bullet movement
        public void Movement()
        {
            // rigidbody.AddForce(bulletView.transform.forward * bulletModel.bulletForce, ForceMode.Impulse);

            Vector3 move = bulletView.transform.transform.position;
            move += bulletView.transform.forward * bulletModel.bulletForce * Time.fixedDeltaTime;

            rigidbody.MovePosition(move);
        }
    }
}