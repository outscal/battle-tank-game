using System;
using System.Collections;
using System.Collections.Generic;
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

        public void SetEnemyController(EnemyController ec)
        {
            enemyController = ec;
        }
    }
}