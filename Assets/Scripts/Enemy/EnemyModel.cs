using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyModel : IModel
    {
        public EnemyModel(EnemyScriptableObj enemyScriptableObj)
        {
            M_EnemyType = enemyScriptableObj.enemyType;
            M_Speed = enemyScriptableObj.EnemyTankSpeed;
            M_Health = enemyScriptableObj.Health;
            M_TankDamageBooster = enemyScriptableObj.EnemyDamageBooster;
            M_TurnSpeed = enemyScriptableObj.EnemyTurnSpeed;
            M_EnemyNumber = enemyScriptableObj.EnemyNumber;
            M_PitchRange = enemyScriptableObj.PitchRange;
            M_BulletLaunchForce = enemyScriptableObj.BulletLaunchForce;
            M_EnemyView = enemyScriptableObj.enemyView;
            M_SpawnPointSafe = enemyScriptableObj.EnemySpawnSafe;
            M_EnemySpawnPoint1 = enemyScriptableObj.EnemySpawnPoint1;
            M_EnemySpawnPoint2 = enemyScriptableObj.EnemySpawnPoint2;
        }

        public EnemyType M_EnemyType;
        public int M_Speed { get; }
        public float M_Health { get; }
        public float M_TankDamageBooster { get; }
        public int M_EnemyNumber { get; }
        public float M_PitchRange { get; }
        public float M_BulletLaunchForce { get; }
        public float M_TurnSpeed { get; }
        public EnemyView M_EnemyView { get; }
        public Transform M_SpawnPointSafe { get; }
        public Transform M_EnemySpawnPoint1 { get; }
        public Transform M_EnemySpawnPoint2 { get; }

        // Not Used here//////////////////////
        public int M_PlayerNumber { get; }
        public KeyCode FireKey { get; }
        ////////////////////////////////
    }
}
