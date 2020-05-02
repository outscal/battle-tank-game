using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Controller;
using Enemy.View;
using Tank.View;

namespace Bullet.View
{
    public class BulletView : MonoBehaviour
    {
        BulletController bulletController;

        public ParticleSystem BulletExplosion;

        public void SetBulletController(BulletController bc)
        {
            bulletController = bc;
        }

        private void Update()
        {
            FireBullet(transform.eulerAngles);
        }

        public void FireBullet(Vector3 tankRotation)
        {
            transform.eulerAngles = tankRotation;
            transform.position += transform.forward * bulletController.BulletModel.Speed * Time.deltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<EnemyView>() || collision.gameObject.GetComponent<TankView>())
            {
                bulletController.DestroyBullet();
            }else if(collision.gameObject.GetComponent<BoxCollider>() != null)
            {
                InstantiateShellExplosionParticleEffect();
                bulletController.DestroyBullet();
            }
        }

        private void InstantiateShellExplosionParticleEffect()
        {
            Instantiate(BulletExplosion, transform.position, new Quaternion(0f, 0f, 0f, 0f));
        }

        public void DestroyBulletPrefab()
        {
            Destroy(gameObject);
        }
    }
}