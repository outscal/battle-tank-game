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
        public Transform environment;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                SpawnEnemyTanks(i);
            }
            for (int i = 0; i < tankSpawners.Length; i++)
            {
                SpawnTanks(i);
            }
        }

        public void DestroyEverything()
        {
            StartCoroutine(Destroy());
        }

        IEnumerator Destroy()
        {  
            yield return StartCoroutine(DestroyEnemies());
            yield return new WaitForSeconds(2f);
            yield return StartCoroutine(DestroyEnvironment());
        }
        IEnumerator DestroyEnemies()
        {
            yield return null;
            EnemyService.Instance.DestroyAllEnemies();
        }

        IEnumerator DestroyEnvironment()
        {
            yield return null;

            foreach (Transform child in environment)
            {
                yield return new WaitForSeconds(0.7f);
                foreach (Transform item in child)
                {
                ParticleService.Instance.CreateTankExplosion(item.transform.position, item.transform.rotation);
                Destroy(child.gameObject);
                }
            }
            //GameObject[] enviroChildren = environment.gameObject.GetComponentsInChildren<GameObject>();
            //foreach (GameObject child in enviroChildren)
            //{
            //    yield return new WaitForSeconds(0.7f);
            //    ParticleService.Instance.CreateTankExplosion(child.transform.position, child.transform.rotation);
            //    Destroy(child, 0.1f);

            //}
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