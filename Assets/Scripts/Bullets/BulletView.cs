using EnemyServices;
using System;
using System.Collections;
using System.Collections.Generic;
using TankServices;
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
            Destroy(gameObject, 2f);
        }

        private void OnCollisionEnter(Collision other)
        {
            if(bulletController.bulletModel.bulletType == BulletType.Enemy && other.gameObject.GetComponent<TankView>() != null)
            {
                TankService.Instance.getTankController().applyDamage(bulletController.bulletModel.Damage);
                DestroyBullet();
            }
            else if(bulletController.bulletModel.bulletType != BulletType.Enemy && other.gameObject.GetComponent<EnemyView>() != null)
            {
                other.gameObject.GetComponent<EnemyView>().enemyController.applyDamage(bulletController.bulletModel.Damage);
                DestroyBullet();
            }
        }

        public void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}
