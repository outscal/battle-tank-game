using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Bullet;
using TankGame.Event;
using System;

namespace TankGame.Enemy
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        public EnemyView enemyView;
        public EnemyScriptableObjectList EnemyList;
        public List<EnemyController> enemyTanks = new List<EnemyController>();
        private Coroutine coroutine;
        private int enemyDeathCounter=0;
        private Vector3 SpawnerPos;
        private Quaternion SpawnerRotation;
        private int EnemyNumber;

        private EnemyPoolService enemyPoolService;

        protected override void Start()
        {
            base.Start();
            enemyPoolService = GetComponent<EnemyPoolService>();
            //SpawnEnemy();
        }

        public void fire(Transform bulletSpawn, float bulletDamange)
        {
            BulletService.Instance.spawnBullet(bulletSpawn, bulletDamange);
        }

        public void SpawnEnemy(Vector3 enemySpawnerPos, Quaternion enemySpawnerRotation, int enemyIndex)

        {
            this.SpawnerPos = enemySpawnerPos;
            this.SpawnerRotation = enemySpawnerRotation;
            this.EnemyNumber =  enemyIndex;

            EnemyModel model = new EnemyModel(EnemyList.enemyScriptableObject[enemyIndex]);
            EnemyController controller = enemyPoolService.GetEnemy(model, enemyView, enemySpawnerPos, enemySpawnerRotation, enemyIndex);
            //EnemyController controller = new EnemyController(model, enemyView, enemySpawnerPos, enemySpawnerRotation, enemyIndex);
            controller.Enable();
            enemyTanks.Add(controller);
        }

        public void DestroyAllEnemies()
        {
            if (coroutine != null)
            {
                StopCoroutine(DestroyAllViews());
            }
            coroutine = StartCoroutine(DestroyAllViews());
        }

        IEnumerator DestroyAllViews()
        {
            EnemyView[] enemy = GameObject.FindObjectsOfType<EnemyView>();
            foreach (EnemyView enemyTank in enemy)
            {
                yield return new WaitForSeconds(1f);
                enemyTank.Destroy();
            }
        }

        public void DestroyTank(EnemyController controller)
        {
            for (int i = 0; i < enemyTanks.Count; i++)
            {
                if (controller == enemyTanks[i])
                {
                    //SpawnerPos = controller.SpawnerPos;
                    //SpawnerRotation = controller.SpawnerRotation;
                    //EnemyNumber = controller.EnemyNumber;
                    SetEnemyCounter();
                    //controller.Destroy();
                    controller.Disable();
                    
                    enemyPoolService.ReturnItem(controller);
                    enemyTanks[i] = null;
                }
            }
        }

        private void SetEnemyCounter()
        {
            enemyDeathCounter = PlayerPrefs.GetInt("KilledEnemies", 0);
            enemyDeathCounter++;
            EventService.Instance.OnEnemyDeath(enemyDeathCounter);
            SpawnEnemyAgain(SpawnerPos, SpawnerRotation, EnemyNumber);
            if (enemyDeathCounter%5 == 0)
            {
                EventService.Instance.OnEnemyKillAchievment(enemyDeathCounter);
            }
        }

        async void SpawnEnemyAgain(Vector3 SpawnerPos, Quaternion SpawnerRotation, int EnemyNumber)
        {
            await new WaitForSeconds(2f);
            SpawnEnemy(SpawnerPos, SpawnerRotation, EnemyNumber);

        }




        //public void TakeDamage(EnemyView enemy, float damage)
        //{
        //    for (int i = 0; i < EnemyList.enemyScriptableObject.Length; i++)
        //    {
        //        if(enemy.GetController().EnemyModel.EnemyTankType == EnemyList.enemyScriptableObject[i].EnemyType)
        //        {
        //            EnemyList.enemyScriptableObject[i].TankHealth -= damage;
        //            Debug.Log("enemy health= " + EnemyList.enemyScriptableObject[i].TankHealth);
        //            EnemyModel model = new EnemyModel(EnemyList.enemyScriptableObject[i]);
        //            enemy.SetViewDetails(model, EnemyList.enemyScriptableObject[i]);
        //        }
        //    }
        //}
    }
}
