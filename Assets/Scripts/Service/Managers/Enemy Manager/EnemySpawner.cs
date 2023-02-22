using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.ObjectPool;
using Tank.EventService;
namespace Tanks.Service
{
    public class EnemySpawner : Singleton<EnemySpawner>
    {
        public EnemyTankList tankObjectList;
        private Transform spawn;
        private EnemyPool pool;
        public int enemyWave;
        private int enemyCount;
        private int deathCount;
        private void OnEnable()
        {
            EventManagement.OnEnemyDeath += EnemyDeaths;
            spawn = this.transform;
            enemyWave = 1;
        }
        private void OnDisable()
        {
            EventManagement.OnEnemyDeath -= EnemyDeaths;
        }
        private void Start()
        {
            pool = this.gameObject.GetComponent<EnemyPool>();
            Debug.Log("enemyspawner start");
            EnemyWaves(enemyWave);
        }
        private void TankSpawn(int i)
        {
            Debug.Log("enemyspawner tankspawn");
            pool.GetTank(tankObjectList.EnemyTanks[0]);
        }
        private void EnemyWaves(int currentWave)
        {
            Debug.Log("enemyspawner enemy wave");
             enemyCount = 1;//increasing enemy by wave number not implemented yet
            switch (currentWave)
            {
                case 1:
                    enemyCount = 1;
                    break;
                case 2:
                    enemyCount = 2;
                    break;
                case 3:
                    enemyCount = 3;
                    break;
                case 4:
                    enemyCount = 4;
                    break;
                case 5:
                    enemyCount = 5;
                    break;
                case 6:
                    enemyCount = 6;
                    break;
                default:
                    break;
            }
            for (int i = 1; i <= enemyCount; i++)
            {
                TankSpawn(Random.Range(0, tankObjectList.EnemyTanks.Length - 1));
            }
        }
        public void EnemyDeaths()
        {
            if(deathCount == enemyCount)
            {
                EventManagement.Instance.WaveComplete(enemyWave);
                EnemyWaves(enemyWave += 1);
            }
        }
    }
}
