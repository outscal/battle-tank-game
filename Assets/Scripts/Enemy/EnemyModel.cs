using UnityEngine;
using ScriptableObj;

namespace Enemy
{
    public class EnemyModel
    {
        public EnemyModel(EnemyScriptableObj enemyScriptableObj)
        {
            EnemyType = enemyScriptableObj.EnemyType;
            Speed = enemyScriptableObj.EnemyTankSpeed;
            Health = enemyScriptableObj.Health;
            TankDamageBooster = enemyScriptableObj.EnemyDamageBooster;
            TurnSpeed = enemyScriptableObj.EnemyTurnSpeed;
            EnemyNumber = enemyScriptableObj.EnemyNumber;
            PitchRange = enemyScriptableObj.PitchRange;
            BulletLaunchForce = enemyScriptableObj.BulletLaunchForce;
            EnemyView = enemyScriptableObj.EnemyView;
            SpawnPointSafe = enemyScriptableObj.EnemySpawnSafe;
            EnemySpawnPoint1 = enemyScriptableObj.EnemySpawnPoint1;
            EnemySpawnPoint2 = enemyScriptableObj.EnemySpawnPoint2;
        }

        public EnemyType EnemyType;
        public int Speed { get; }
        public float Health { get; }
        public float TankDamageBooster { get; }
        public int EnemyNumber { get; }
        public float PitchRange { get; }
        public float BulletLaunchForce { get; }
        public float TurnSpeed { get; }
        public EnemyView EnemyView { get; }
        public Transform SpawnPointSafe { get; }
        public Transform EnemySpawnPoint1 { get; }
        public Transform EnemySpawnPoint2 { get; }
    }
}
