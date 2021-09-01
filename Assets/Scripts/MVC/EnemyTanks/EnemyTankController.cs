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
<<<<<<< HEAD

        public void CreateBullet()
        {
            BulletService.Instance.CreateNewBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }

        public Vector3 GetRandomPosition()
=======
        //enemy tank shooting function
        public void ShootBullet()
        {
            BulletService.Instance.CreateNewBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }
        //enemy tank will take damage
        public void ApplyDamage(int damage)
>>>>>>> 7c0e24283da20dcd65e68d6409b96ef27d2d0bc8
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
<<<<<<< HEAD

        public void EnemyPatrollingAI()
=======
        //trigger when enemy dead
        public void Dead()
>>>>>>> 7c0e24283da20dcd65e68d6409b96ef27d2d0bc8
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
<<<<<<< HEAD

        private void ChaseToPlayer()
=======
        //enemy tank gets firing position 
        public Vector3 GetFiringPosition()
>>>>>>> 7c0e24283da20dcd65e68d6409b96ef27d2d0bc8
        {
            EnemyTankView.transform.LookAt(EnemyTankView.playerTransform);
            EnemyTankView.navMeshAgent.SetDestination(EnemyTankView.playerTransform.position);
            ShootBullet();
        }
<<<<<<< HEAD


        private void ShootBullet()
=======
        //enemy tank gets firing angle
        public Quaternion GetFiringAngle()
>>>>>>> 7c0e24283da20dcd65e68d6409b96ef27d2d0bc8
        {
            if (EnemyTankView.canFire < Time.time)
            {
                EnemyTankView.canFire = EnemyTankModel.fireRate + Time.time;
                CreatingBullet();
            }
        }
<<<<<<< HEAD

        public void CreatingBullet()
=======
        //enemy tank gets bullet
        public BulletScriptableObject GetBullet()
>>>>>>> 7c0e24283da20dcd65e68d6409b96ef27d2d0bc8
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
        //enemy tank destroy
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