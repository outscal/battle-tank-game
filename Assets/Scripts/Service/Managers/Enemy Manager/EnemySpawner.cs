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
        public int enemyWave = 1;
        private int enemyCount = 0;
        private int deathCount = 0;
        private void OnEnable()
        {
            EventManagement.OnEnemyDeath += EnemyDeaths;
            spawn = this.transform;
        }
        private void OnDisable()
        {
            EventManagement.OnEnemyDeath -= EnemyDeaths;
        }
        private void Start()
        {
            pool = this.gameObject.GetComponent<EnemyPool>();
            EnemyWaves(enemyWave);
        }
        private void TankSpawn(int i)
        {
            pool.GetTank(tankObjectList.EnemyTanks[i]);
        }
        private void EnemyWaves(int currentWave)
        {
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
            deathCount ++;
            if(deathCount == enemyCount)
            {
                EventManagement.Instance.WaveComplete(enemyWave);
                EnemyWaves(enemyWave += 1);
                deathCount = 0;
            }
        }
    }
}
