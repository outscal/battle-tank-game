using System.Collections;
using System.Collections.Generic;
using TankGame.Tank;
using UnityEngine;

namespace TankGame.Enemy
{
    public class EnemyController
    {
        public EnemyController(EnemyModel enemyModel, EnemyView enemyView, Vector3 spawnerPos, Quaternion spawnerRotation, EnemyScriptableObject enemyScriptableObject)
        {
            EnemyModel = enemyModel;
            SpawnerPos = spawnerPos;
            EnemyView = GameObject.Instantiate<EnemyView>(enemyView, SpawnerPos, spawnerRotation);
            EnemyView.SetViewDetails(EnemyModel, enemyScriptableObject);
            EnemyView.InitializeController(this);
        }
        
        public void TakeDamage(EnemyView enemy, float damage)
        {
            enemy.ApplyEnemyDamage(damage);
        }

        public void DestroyEnemyView(EnemyView enemyView)
        {
            EnemyService.Instance.DestroyView(enemyView);
        }
        public EnemyView EnemyView { get; }
        public EnemyModel EnemyModel { get; }
        public Vector3 SpawnerPos { get; }
    }
}