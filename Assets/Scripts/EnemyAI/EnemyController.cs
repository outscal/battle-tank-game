using System.Collections;
using System.Collections.Generic;
using TankGame.Tank;
using UnityEngine;

namespace TankGame.Enemy
{
    public class EnemyController
    {
        public EnemyController(EnemyModel enemyModel, EnemyView enemyPrefab, Vector3 spawnerPos, Quaternion spawnerRotation)
        {
            EnemyModel = enemyModel;
            SpawnerPos = spawnerPos;
            EnemyPrefab = GameObject.Instantiate<EnemyView>(enemyPrefab, SpawnerPos, spawnerRotation);
            EnemyPrefab.SetViewDetails(EnemyModel);
        }
        public EnemyView EnemyPrefab { get; }
        public EnemyModel EnemyModel { get; }
        public Vector3 SpawnerPos { get; }
    }
}