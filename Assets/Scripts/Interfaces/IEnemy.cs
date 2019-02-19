using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using System;
using Audio;

namespace Interfaces
{
    public interface IEnemy : IService
    {
        event Action enemySpawned;
        event Action<AudioName> DestroyEnemySoundFX;
        event Action<int> EnemiesKillCount;
        event Action<Vector3> AlertMode;
        event Action<int> EnemyDestroyed;

        void AlertEnemies(Vector3 position);
        void SpawnEnemy();
        void DestroyEnemy(EnemyController _enemyController);

        int GetEnemiesKilled();
        List<EnemyController> GetEnemyControllerList();
        EnemyData GetEnemyData(int index);
        void SetEnemyData(int index, EnemyData data);
    }
}