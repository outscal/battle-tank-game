using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TankServices;

namespace BulletServices
{
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

        public void Movement()
        {
            // bulletView.transform.Translate(Vector3.forward * bulletModel.speed * Time.deltaTime);
            Vector3 move = bulletView.transform.transform.position += bulletView.transform.forward * bulletModel.speed * Time.fixedDeltaTime;

            rigidbody.MovePosition(move);
        }

        public void DestroyController()
        {
            bulletView.DestroyView();
            bulletModel.DestroyModel();
            bulletView = null;
            bulletModel = null;
            rigidbody = null;
        }
    }
}