using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Bullet;

namespace TankGame.Enemy
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {

        public EnemyView enemyView;
        public EnemyScriptableObjectList EnemyList;
        //public Color[] enemyColor;
        //public float[] enemyHealth;
        //public float[] enemyDamage;

        private void Start()
        {
            //SpawnEnemy();
        }

        public void fire(Transform bulletSpawn, float bulletDamange)
        {
            BulletService.Instance.spawnBullet(bulletSpawn, bulletDamange);
        } 

        public void SpawnEnemy(Vector3 enemySpawnerPos, Quaternion enemySpawnerRotation, int enemyIndex)

        {
            EnemyModel model = new EnemyModel(EnemyList.enemyScriptableObject[enemyIndex]);
            EnemyController controller = new EnemyController(model, enemyView, enemySpawnerPos, enemySpawnerRotation);
        }



    }
}
