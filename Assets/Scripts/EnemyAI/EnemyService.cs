using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Bullet;

namespace TankGame.Enemy
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {

        public EnemyView enemyView;
        public Color[] enemyColor;
        public float[] enemyHealth;
        public float[] enemyDamage;

        private void Start()
        {
            //SpawnEnemy();
        }

        public void fire(Transform bulletSpawn, float bulletDamange)
        {
            BulletService.Instance.spawnBullet(bulletSpawn, bulletDamange);
        } 

        public void SpawnEnemy(Vector3 enemySpawnerPos, Quaternion enemySpawnerRotation, int enemyNumber)
        {
            EnemyModel model = new EnemyModel(250, 100, enemyHealth[enemyNumber], enemyDamage[enemyNumber], enemyColor[enemyNumber]);
            EnemyController controller = new EnemyController(model, enemyView, enemySpawnerPos, enemySpawnerRotation);
        }



    }
}
