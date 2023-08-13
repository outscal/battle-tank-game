using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTank
{
    public class EnemyModel
    {
        private EnemyController enemyController;
        public float speed { get; }
        public float health { get; }
        public int strength { get; }
        public float chasingRadius { get; }
        public float ShootCoolDown { get; }
        public float ShootingDistace { get; }

        public EnemyModel(EnemyScriptableObject enemy)
        {
            speed = enemy.Speed;
            health = enemy.Health;
            chasingRadius = enemy.AIVisibilityRadius;
            ShootCoolDown = enemy.ShootCoolDown;
            ShootingDistace = enemy.AIShootingDistance;
            strength = enemy.strength;



        }
        public void SetEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }
       

    }
}