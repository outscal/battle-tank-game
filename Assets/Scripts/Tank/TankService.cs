using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Bullet;
using TankGame.Enemy;
using TankGame.Spawner;
using System;

namespace TankGame.Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public event Action PlayerSpawn;
        public TankView tankView;
        public TankScriptableObjectList tankList;
        public List<TankController> tanks = new List<TankController>();
        TankController controller;


        protected override void Awake()
        {
            base.Awake();
        }
        protected override void Start()
        {
            base.Start();
            EnemyService.Instance.OnDeath += CheckEnemyDeath;
        }



        private void CheckEnemyDeath()
        {
            Debug.Log("Enemy Died");
        }

        public void fire(Transform bulletSpawn, float bulletDamange)
        {
            BulletService.Instance.spawnBullet(bulletSpawn, bulletDamange);
        }
        public void DestroyTank(TankController controller)
        {
            //StartCoroutine(RestartTank());
            for (int i = 0; i < tanks.Count; i++)
            {
                if(controller == tanks[i])
                {
                    controller.Destroy();
                }
            }
            StartCoroutine(DestroySsceneObjects());
        }
      
        public TankView GetCurrentPlayer()
        {
            return tanks[0].GetTankView();
        }

        IEnumerator DestroySsceneObjects()
        {
            yield return new WaitForSeconds(3f);
            SpawnerService.Instance.DestroyEverything();
        }

        //IEnumerator RestartTank()
        //{
        //    yield return new WaitForSeconds(3f);
        //    SpawnerService.Instance.SpawnTanks(0);
        //}
        public void SpawnTankPrefab(Transform spawner, int tankSerial)
        {
            TankModel model = new TankModel(tankList.tankScriptableObject[0]);
            TankController tank = new TankController(model, tankView, spawner);
            PlayerSpawn?.Invoke();
            tanks.Add(tank);
            //return tank;
        }
    }
}