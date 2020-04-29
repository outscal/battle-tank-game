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

        protected override void Start()
        {
            base.Start();
            //SpawnEnemy();
        }

        public void fire(Transform bulletSpawn, float bulletDamange)
        {
            BulletService.Instance.spawnBullet(bulletSpawn, bulletDamange);
        }

        public void SpawnEnemy(Vector3 enemySpawnerPos, Quaternion enemySpawnerRotation, int enemyIndex)

        {
            EnemyModel model = new EnemyModel(EnemyList.enemyScriptableObject[enemyIndex]);
            EnemyController controller = new EnemyController(model, enemyView, enemySpawnerPos, enemySpawnerRotation, enemyIndex, EnemyList.enemyScriptableObject[enemyIndex]);
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
                    controller.Destroy();
                    SetEnemyCounter(controller);
                    enemyTanks[i] = null;
                }
            }
        }

        private void SetEnemyCounter(EnemyController currController)
        {
            
            enemyDeathCounter++;
            EventService.Instance.OnEnemyDeath(enemyDeathCounter);
            SpawnEnemyAgain(currController);

            if (enemyDeathCounter%5 == 0)
            {
                EventService.Instance.OnEnemyKillAchievment(enemyDeathCounter);
            }
        }

        async void SpawnEnemyAgain(EnemyController currController)
        {
            await new WaitForSeconds(2f);
            SpawnEnemy(currController.SpawnerPos, currController.SpawnerRotation, currController.EnemyNumber);

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
