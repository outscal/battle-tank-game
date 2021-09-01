using System;
using UnityEditor;
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
        //enemy tank shooting function
        public void ShootBullet()
        {
            BulletService.Instance.CreateNewBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }
        //enemy tank will take damage
        public void ApplyDamage(int damage)
        {
            EnemyTankModel.Health -= damage;
            Debug.Log("enemy health: " + EnemyTankModel.Health);
            if (EnemyTankModel.Health <= 0)
            {
                Dead();
            }
        }
        //trigger when enemy dead
        public void Dead()
        {
            EnemyTankService.Instance.DestroyEnemyTank(this);
        }
        //enemy tank gets firing position 
        public Vector3 GetFiringPosition()
        {
            return EnemyTankView.bulletShootPoint.position;
        }
        //enemy tank gets firing angle
        public Quaternion GetFiringAngle()
        {
            return EnemyTankView.transform.rotation;
        }
        //enemy tank gets bullet
        public BulletScriptableObject GetBullet()
        {
            return EnemyTankModel.bulletType;
        }
        //enemy tank destroy
        public void DestroyEnemyController()
        {
            EnemyTankModel.DestroyModel();
            EnemyTankView.DestroyView();
            EnemyTankModel = null;
            EnemyTankView = null;
        }
    }
}