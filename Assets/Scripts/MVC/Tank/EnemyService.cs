using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Assets.Scripts.MVC.Tank
{
    public class EnemyService : MonoBehaviour
    {
        public EnemyView EnemyView;
        public BulletView BulletView;
        public EnemyScriptableObject[] enemyConfigurations;
        private String x;
        private EnemyController enemy;
        public NavMeshAgent xxx;

        // Use this for initialization
        void Start()
        {
            EnemyScriptableObject enemyScriptableObject = enemyConfigurations[Random.Range(0, 2)];
            EnemyModel model = new EnemyModel(enemyScriptableObject);

            enemy = new EnemyController(model, EnemyView);
            x = model.TankName;
            xxx = BulletView.gameObject.AddComponent<NavMeshAgent>();
        }

        public Vector3 RandomSpawnLocation()
        {
            float spawnXRange = Random.Range(-14, 15);
            float spawnZRange = Random.Range(-15, 17);
            float Y = 0;

            return new Vector3(spawnXRange, Y, spawnZRange);

        }

        void FireBullet()
        {
            Instantiate(BulletView, EnemyView.gameObject.transform.position, Quaternion.identity);
            
            
        }

        // Update is called once per frame
        void Update()
        {
            enemy.nextPosition();
            Debug.Log(x);
            Debug.Log(EnemyView.transform.position);
            
           // xxx.SetDestination(RandomSpawnLocation());
           // enemy.Fire();
        }

    }
} 