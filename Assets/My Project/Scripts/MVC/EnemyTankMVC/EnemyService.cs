using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace BattleTank
{
    public class EnemyService : GenericSingleTon<EnemyService>
    {
        [SerializeField] EnemyScriptableObjectList enemyTankList;
        [SerializeField] int enemyCount = 3;
        [SerializeField] ParticleSystem tankExplosion;
        List<EnemyController> enemies;
        void Start()
        {
            enemies = new List<EnemyController>();
            for (int i = 0; i < enemyCount; i++)
            {
                EnemyController enemyController = CreateEnemyTank(UnityEngine.Random.Range(0, enemyTankList.enemies.Length));
                enemies.Add(enemyController);
            }
        }
        public EnemyController CreateEnemyTank(int index)
        {
            EnemyScriptableObject enemy = enemyTankList.enemies[index];
            EnemyController enemyController = new EnemyController(enemy, 50, -10);
            return enemyController;
        }
        public void ShootBullet( Transform tankTransform)
        {
            BulletService.Instance.BulletShootByTank(tankTransform);
        }
        public void DestoryEnemy(EnemyController _enemyController)
        {
            Vector3 pos = _enemyController.GetPosition();
            Destroy(_enemyController.enemyView.gameObject);
            StartCoroutine(TankExplosion(pos));
            enemies.Remove(_enemyController);
          
        }
        public IEnumerator TankExplosion(Vector3 tankPos)
        {
            ParticleSystem newTankExplosion = GameObject.Instantiate<ParticleSystem>(tankExplosion, tankPos, Quaternion.identity);
            newTankExplosion.Play();
            yield return new WaitForSeconds(2f);
            Destroy(newTankExplosion.gameObject);
        }
        public IEnumerator DestroyAllEnemies()
        {
            yield return new WaitForSeconds(2f);
            List<EnemyController> enemyList = new List<EnemyController>(enemies);
            foreach (EnemyController enemy in enemyList)
            {
                DestoryEnemy(enemy);
                yield return new WaitForSeconds(2f);
            }
        }
    }
}