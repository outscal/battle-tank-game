using System;
using System.Collections;
using System.Collections.Generic;
using Bullet.View;
using Enemy.Controller;
using UnityEngine;

namespace Enemy.View
{
    public class EnemyView : MonoBehaviour
    {
        EnemyController enemyController;

        private void Start()
        {
            Debug.Log("Enemy View Created");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                enemyController.FireBullet();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<BulletView>() != null)
            {
                Debug.Log("if function called");
                DestroyEnemy();
                DestroyBullet();
            }
        }

        private void DestroyEnemy()
        {
            Debug.Log("Destroy Enemy");
        }

        private void DestroyBullet()
        {
            Debug.Log("bullet view destroyed...");
            //bulletController.DestroyController();
            //Destroy(gameObject);
        }

        public void SetEnemyController(EnemyController ec)
        {
            enemyController = ec;
        }
    }
}