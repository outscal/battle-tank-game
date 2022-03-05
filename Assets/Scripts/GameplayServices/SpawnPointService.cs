using GlobalServices;
using UnityEngine;
using System.Collections;

namespace GameplayServices
{
    public class SpawnPointService : MonoSingletonGeneric<SpawnPointService>
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private Transform enemySpawnPoint;

        public Transform GetPlayerSpawnPoint()
        {
            return playerSpawnPoint;
        }
        public Transform GetEnemySpawnPoint()
        {
            return enemySpawnPoint;
        }

    }
}

