using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Bullet;
using System;

namespace TankGame.Enemy
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        public event Action OnDeath;
        public EnemyView enemyView;
        public EnemyScriptableObjectList EnemyList;
        public List<EnemyController> enemyTanks = new List<EnemyController>();
        private Coroutine coroutine;

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
            EnemyController controller = new EnemyController(model, enemyView, enemySpawnerPos, enemySpawnerRotation, EnemyList.enemyScriptableObject[enemyIndex]);
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
                    OnDeath?.Invoke();

                }
            }
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
