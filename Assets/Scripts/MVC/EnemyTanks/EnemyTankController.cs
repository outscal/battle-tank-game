using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank 
{
    /// <summary>
    /// enemy tnak controller class
    /// </summary>
    public class EnemyTankController
    {
        public EnemyTankModel EnemyTankModel { get; set; }
        public EnemyTankView EnemyTankView { get; private set; }

        public EnemyTankController(EnemyTankModel enemyTankModel, EnemyTankView enemyTankView, Vector3 pos)
        {
            EnemyTankModel = enemyTankModel;
            EnemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView, pos, Quaternion.identity);
            EnemyTankModel.SetEnemyTankController(this);
            EnemyTankView.SetEnemyTankController(this);
        }

        public void CreateBullet()
        {
            BulletService.Instance.CreateNewBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }

        public Vector3 GetRandomPosition()
        {
            float x = Random.Range(EnemyTankView.minX, EnemyTankView.maxX);
            float z = Random.Range(EnemyTankView.minZ, EnemyTankView.maxZ);
            Vector3 randomDir = new Vector3(x, 0, z);
            return randomDir;
        }

        private void SetPatrolingDestination()
        {
            Vector3 newDestination = GetRandomPosition();
            EnemyTankView.navMeshAgent.SetDestination(newDestination);
            // Debug.Log(newDestination);
        }

        public void Patrol()
        {
            EnemyTankView.timer += Time.deltaTime;
            if (EnemyTankView.timer > EnemyTankView.patrollTime)
            {
                SetPatrolingDestination();
                EnemyTankView.timer = 0;
            }
        }

        public void EnemyPatrollingAI()
        {
            if (TankService.Instance.PlayerPos() != null)
            {
                float distance = Vector3.Distance(TankService.Instance.PlayerPos().position, EnemyTankView.transform.position);
                if (distance <= EnemyTankView.howClose)
                {
                    ChaseToPlayer();
                    ShootBullet();
                }
                else
                {
                     Patrol();
                }
            }
            else
            {
                Patrol();
            }
        }

        private void ChaseToPlayer()
        {
            EnemyTankView.transform.LookAt(EnemyTankView.playerTransform);
            EnemyTankView.navMeshAgent.SetDestination(EnemyTankView.playerTransform.position);
            ShootBullet();
        }


        private void ShootBullet()
        {
            if (EnemyTankView.canFire < Time.time)
            {
                EnemyTankView.canFire = EnemyTankModel.fireRate + Time.time;
                CreatingBullet();
            }
        }

        public void CreatingBullet()
        {
            BulletService.Instance.CreateNewBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }

        public void Dead()
        {
            EnemyTankService.Instance.DestroyEnemyTank(this);
        }

        public void ApplyDamage(int damage)
        {
            EnemyTankModel.Health -= damage;
            Debug.Log("Enemy Health : " + EnemyTankModel.Health);

            if (EnemyTankModel.Health <= 0)
            {
                Debug.Log("Dead called");
                Dead();
            }
        }

        public void DestroyEnemyController()
        {
            EnemyTankModel.DestroyModel();
            EnemyTankView.DestroyView();
            EnemyTankModel = null;
            EnemyTankView = null;
        }

        public Vector3 GetFiringPosition()
        {
            return EnemyTankView.bulletShootPoint.position;
        }
        public Quaternion GetFiringAngle()
        {
            return EnemyTankView.transform.rotation;
        }
        public BulletScriptableObject GetBullet()
        {
            return EnemyTankModel.bulletType;
        }
    }
}