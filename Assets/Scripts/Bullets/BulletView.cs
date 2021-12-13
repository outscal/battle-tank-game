using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletServices
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController { get; private set; }
        public Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        private void FixedUpdate()
        {
            BulletMove();
        }

        public void BulletMove()
        {
            Vector3 move = transform.position;
            move += transform.forward * bulletController.bulletModel.Speed * Time.fixedDeltaTime;
            rb.MovePosition(move);
            DestroyBullet();
        }

        public void DestroyBullet()
        {
            Destroy(gameObject, 2f);
        }
    }
}
