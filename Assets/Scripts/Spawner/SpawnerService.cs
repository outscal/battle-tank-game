using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TankGame.Tank;
using TankGame.Enemy;
using TankGame.UI;

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
        private int childContetnt;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            UIService.Instance.SetIntroText();
            StartCoroutine(Spawning());
        }

        IEnumerator Spawning()
        {
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < tankSpawners.Length; i++)
            {
                SpawnTanks(i);
            }
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                SpawnEnemyTanks(i);
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
                childContetnt++;
                foreach (Transform item in child)
                {
                ParticleService.Instance.CreateTankExplosion(item.transform.position, item.transform.rotation);
                Destroy(child.gameObject);
                }
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