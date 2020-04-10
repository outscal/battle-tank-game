using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Tank;
using TankGame.Enemy;

namespace TankGame.Spawner
{
    public class SpawnerService : MonoSingletonGeneric<SpawnerService>
    {
        //private SpawnerModel[] model = new SpawnerModel[3];
        //public SpawnerView spawnerView;
        public Transform[] tankSpawners;
        public Transform[] enemySpawners;
        private Transform enemySpawnersTransform;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                //    model[i] = new SpawnerModel(spawners[i].transform.position);
                //    SpawnerController spawnerController = new SpawnerController(model[i], spawnerView);
                SpawnEnemyTanks(i);
            }
            for (int i = 0; i < tankSpawners.Length; i++)
            {
                SpawnTanks(i);
            }
        }

        public void SpawnTanks(int tankNumber)
        {
            TankService.Instance.SpawnTankPrefab(tankSpawners[tankNumber], tankNumber);
        }
        public void SpawnEnemyTanks(int enemyNumber)
        {
            enemySpawnersTransform = enemySpawners[enemyNumber].transform;
            EnemyService.Instance.SpawnEnemy(enemySpawnersTransform.position, enemySpawnersTransform.rotation, enemyNumber);
        }
    }

}