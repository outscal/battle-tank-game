using System;
using System.Collections;
using System.Collections.Generic;
using Bullet.View;
using Enemy.Controller;
using Tank.View;
using UnityEngine;

namespace Enemy.View
{
    public class EnemyView : MonoBehaviour
    {
        EnemyController enemyController;
        //public GameObject TankExplosion;
        public ParticleSystem TankExplosion;

        public void SetEnemyController(EnemyController ec)
        {
            enemyController = ec;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                enemyController.FireBullet(transform.position, transform.eulerAngles);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<BulletView>() != null)
            {
                enemyController.DestroyEnemyTank();
            }
        }

        public void DestroyEnemyTankPrefab()
        {
            Destroy(gameObject);
        }

        public void InstantiateTankExplosionParticleEffect()
        {
            Instantiate(TankExplosion, transform.position, new Quaternion(0f, 0f, 0f, 0f));
        }
    }
}