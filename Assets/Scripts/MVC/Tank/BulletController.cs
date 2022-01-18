using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MVC.Tank
{
    public class BulletController
    {
        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }

        public BulletController(BulletModel bulletModel, BulletView bulletPrefab)
        {
            BulletModel = bulletModel;
           // BulletView = bulletPrefab;
            //BulletView = Object.Instantiate(bulletPrefab, RandomSpawnLocation(), Quaternion.identity);
            BulletView = GameObject.Instantiate<BulletView>(bulletPrefab);
            BulletView.SetBulletController(this);
        }

        public Vector3 RandomSpawnLocation()
        {
            float spawnXRange = Random.Range(-14, 15);
            float spawnZRange = Random.Range(-15, 17);
            float Y = 0;

            return new Vector3(spawnXRange, Y, spawnZRange);

        }
        public void SpawnBullet()
        {

            GameObject.Instantiate(BulletView,RandomSpawnLocation(), Quaternion.identity);
            Debug.Log("Bullet Spawneed in bullet controller");

        }

      
    }
}