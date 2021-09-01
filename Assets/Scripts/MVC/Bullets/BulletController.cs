using System;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// bullet control logics
    /// </summary>
    public class BulletController 
    {
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
            Vector3 move = bulletView.transform.transform.position;
            //move += bulletView.transform.forward * bulletModel.BulletForce * Time.fixedDeltaTime;
            move += bulletModel.BulletForce * Time.fixedDeltaTime * bulletView.transform.forward;
            rigidbody.MovePosition(move);
        }

    }
}