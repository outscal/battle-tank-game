using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyModel : IModel
    {
        public EnemyModel(EnemyScriptableObj enemyScriptableObj)
        {
            M_Speed = enemyScriptableObj.EnemyTankSpeed;
            M_Health = enemyScriptableObj.Health;
            M_TankDamageBooster = enemyScriptableObj.EnemyDamageBooster;
            M_TurnSpeed = enemyScriptableObj.EnemyTurnSpeed;
            M_EnemyNumber = enemyScriptableObj.EnemyNumber;
            M_PitchRange = enemyScriptableObj.PitchRange;
            M_BulletLaunchForce = enemyScriptableObj.BulletLaunchForce;
            M_EnemyView = enemyScriptableObj.enemyView;
            M_SpawnPoint = enemyScriptableObj.EnemySpawnPoint;
        }

        public int M_Speed { get; }
        public float M_Health { get; }
        public float M_TankDamageBooster { get; }
        public int M_EnemyNumber { get; }
        public float M_PitchRange { get; }
        public float M_BulletLaunchForce { get; }
        public float M_TurnSpeed { get; }
        public EnemyView M_EnemyView { get; }
        public Transform M_SpawnPoint { get; }

        // Not Used//////////////////////
        public int M_PlayerNumber { get; }
        public KeyCode FireKey { get; }
        ////////////////////////////////
    }
}
