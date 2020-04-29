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

        private void Start()
        {
            //Debug.Log("Enemy View Created");
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
                //Debug.Log("if function called");
                DestroyEnemy();
                //DestroyBullet();
            }
        }

        private void DestroyEnemy()
        {
            //Debug.Log("Enemy view destroyed");
            enemyController.SetOffParticleEffect(transform.position);
            enemyController.DestroyController();
            Destroy(gameObject);
        }

        public void SetEnemyController(EnemyController ec)
        {
            enemyController = ec;
        }

        public void DestroyView()
        {
            Destroy(gameObject);
        }

        public void ParticleEffect()
        {
            enemyController.SetOffParticleEffect(transform.position);
        }
    }
}