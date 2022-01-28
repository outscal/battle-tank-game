using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.MVC.Tank
{
    public class EnemyController
    {
        public NavMeshAgent xu;
        private Vector3[] RandomPositions;
        private NavMeshAgent agent;

        public EnemyController(EnemyModel enemyModel, EnemyView tankPrefab)
        {
            EnemyModel = enemyModel;
            EnemyView = Object.Instantiate(tankPrefab, RandomSpawnLocation(), Quaternion.identity);
            Debug.Log("Enemy Controller created");
            agent = EnemyView.gameObject.AddComponent<NavMeshAgent>();
           
            //gameObject.AddComponent<NavMeshAgent>();

        }


        public Vector3 RandomSpawnLocation()
        {
            float spawnXRange = Random.Range(-14, 15);
            float spawnZRange = Random.Range(-15, 17);
            float Y = 0;

            return new Vector3(spawnXRange, Y, spawnZRange);

        }

        public void nextPosition()
        {
            agent.SetDestination(RandomSpawnLocation());
        }

        public void Fire()
        {
            
            Debug.Log("Bullet Spawneer");
        }

        public EnemyModel EnemyModel { get; }
        public EnemyView EnemyView { get; }
        public BulletView BulletView { get; }
        public BulletController BulletController{ get; }
    }
}