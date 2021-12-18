using BulletServices;
using JetBrains.Annotations;
using UnityEngine;

namespace EnemyServices
{
    public class EnemyController
    {
        public EnemyModel enemyModel { get; private set; }
        public EnemyView enemyView { get; private set; }

        public EnemyController(EnemyModel model, EnemyView view, Vector3 pos)
        {
            enemyModel = model;
            enemyView = GameObject.Instantiate<EnemyView>(view, pos, Quaternion.identity);
            enemyView.setEnemyController(this);
            enemyModel.setEnemyController(this);
        }

        public void Move()
        { 
            if(enemyView.playerTransform != null)
            {
                float distance = Vector3.Distance(enemyView.transform.position, enemyView.playerTransform.position);
                if(distance <= enemyView.followRadius)
                {
                    Follow();
                }
                else
                {
                    Patrol();
                }
            }
        }

        public void Follow()
        {
            enemyView.transform.LookAt(enemyView.playerTransform);
            enemyView.agent.SetDestination(enemyView.playerTransform.position);
            shootBullet();
        }

        private void shootBullet()
        {
            if(enemyView.canFire < Time.time)
            {
                enemyView.canFire = enemyModel.fireRate + Time.time;
                BulletService.Instance.CreateBullet(enemyView.shootPoint.position, enemyView.transform.rotation, enemyModel.bulletType);
            }
        }

        public void Patrol()
        {
            enemyView.timer += Time.deltaTime;
            if(enemyView.timer > enemyView.patrolTime)
            {
                Vector3 newDestination = GetRandomPos();
                enemyView.agent.SetDestination(newDestination);
                enemyView.timer = 0f;
            }
        }

        private Vector3 GetRandomPos()
        {
            float x = Random.Range(enemyView.minX, enemyView.maxX);
            float z = Random.Range(enemyView.minZ, enemyView.maxZ);
            Vector3 randDir = new Vector3(x, 0f, z);
            return randDir;
        }

        public void applyDamage(float damage)
        {
            enemyModel.health -= damage;
            if(enemyModel.health <= 0)
            {
                enemyDead();
            }
        }

        public void enemyDead()
        {
            EnemyService.Instance.destroyEnemyTank(this);
        }

        public void destroyEnemyController()
        {
            enemyModel.destroyModel();
            enemyView.destroyView();
            enemyModel = null;
            enemyView = null;
        }
    }
}
