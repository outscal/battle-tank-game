using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MVC.Tank
{
    public class EnemyController 
    {

        public EnemyController(EnemyModel enemyModel, EnemyView tankPrefab)
        {
            EnemyModel = enemyModel;
            EnemyView = Object.Instantiate(tankPrefab, RandomSpawnLocation(), Quaternion.identity);
            Debug.Log("Enemy Controller created");
        }


        public Vector3 RandomSpawnLocation()
        {
            float spawnXRange = Random.Range(-14, 15);
            float spawnZRange = Random.Range(-15, 17);
            float Y = 0;

            return new Vector3(spawnXRange, Y, spawnZRange);
            
        }


        public EnemyModel EnemyModel { get; }
        public EnemyView EnemyView { get; }
    }
}