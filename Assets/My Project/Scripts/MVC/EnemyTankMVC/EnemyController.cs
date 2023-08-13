using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace BattleTank
{
    public class EnemyController
    {

        public EnemyView enemyView { get; }
        public EnemyModel enemyModel { get; }
        private StateBase enemyState;
        private NavMeshAgent agent;
        public Vector3 spawnPoint;
        private Rigidbody rb;
        private float health;
        private float shootCooldown;
        public Transform GetEnemyGunPosition() => enemyView.GetGunPosition();

        public Transform GetEnemyTankTransform() => enemyView.transform;
        public EnemyController(EnemyScriptableObject enemy, float x = 0, float z = 0)
        {
            enemyView = GameObject.Instantiate<EnemyView>(enemy.enemyView, new Vector3(Random.Range(x, -x), 0, Random.Range(z, -z)), Quaternion.identity);
            enemyModel = new EnemyModel(enemy);

            enemyView.SetEnemyController(this);
            enemyModel.SetEnemyController(this);
            enemyState = new Idle(this);
            rb = enemyView.GetRigidbody();
            agent = enemyView.GetAgent();
            health = enemyModel.health;
        }


        public void Shoot(Transform gunTransform)
        {
            EnemyService.Instance.ShootBullet(gunTransform);
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0)
                TankDeath();
        }
        void TankDeath()
        {
            EnemyService.Instance.DestoryEnemy(this);
        }
       
        public Vector3 GetPosition()
        {
            return enemyView.transform.position;
        }
        public NavMeshAgent GetEnemyAgent()
        {
            return agent;
        }
        public int GetStrenth()
        {
            return enemyModel.strength;
        }
       private float DistanceBetbeenTank()
        {
            if(TankService.Instance.GetPlayerTransform() == null)
            {
                return Mathf.Infinity;
            }
            float distance = Vector3.Distance(TankService.Instance.GetPlayerTransform(), enemyView.transform.position);
            return distance;
        }
        public void MoveAITank()
        {
            enemyState = enemyState.Process();
        }
        public bool IsPlayerInChaseRange()
        {
            float distace = DistanceBetbeenTank();
            if(distace < enemyModel.chasingRadius)
            {
                return true;
            }
            return false;
        }
        public bool IsPlayerInShootRange()
        {
            float distance = DistanceBetbeenTank();
            if(distance < enemyModel.ShootingDistace)
            {
                return true;
            }
            return false;
        }
        public void ShootingPlayerTank()
        {
            GetEnemyTankTransform().LookAt(TankService.Instance.GetPlayerTransform());
            shootCooldown += Time.deltaTime;
            if (shootCooldown >= enemyModel.ShootCoolDown)
            {
                shootCooldown = 0;
               BulletService.Instance.BulletShootByTank(enemyView.GetGunPosition());
            }
        }
    }
}