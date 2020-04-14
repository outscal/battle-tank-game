using System.Collections;
using System.Collections.Generic;
using TankGame.Tank;
using UnityEngine;

namespace TankGame.Enemy
{
    public class EnemyController
    {
        public EnemyController(EnemyModel enemyModel, EnemyView enemyView, Vector3 spawnerPos, Quaternion spawnerRotation)
        {
            EnemyModel = enemyModel;
            SpawnerPos = spawnerPos;
            EnemyView = GameObject.Instantiate<EnemyView>(enemyView, SpawnerPos, spawnerRotation);
            EnemyView.SetViewDetails(EnemyModel);
            EnemyView.InitializeController(this);
        }
        
        public void TakeDamage(float damage)
        {
            //EnemyModel.EnemyHealth -= damage;

        }
        public EnemyView EnemyView { get; }
        public EnemyModel EnemyModel { get; }
        public Vector3 SpawnerPos { get; }
    }
}