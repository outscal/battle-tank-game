using UnityEditor;
using UnityEngine;

namespace Outscal.BattleTank 
{
    /// <summary>
    /// enemy tnak controller class
    /// </summary>
    public class EnemyTankController
    {
        public EnemyTankModel EnemyTankModel { get; private set; }
        public EnemyTankView EnemyTankView { get; private set; }


        public EnemyTankController(EnemyTankModel enemyTankModel,EnemyTankView enemyTankView,Vector3 pos)
        {
            EnemyTankModel = enemyTankModel;
            EnemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView,pos,Quaternion.identity);
            EnemyTankModel.SetEnemyTankController(this);
            EnemyTankView.SetEnemyTankController(this);
        }

        public void ShootBullet()
        {
            BulletService.Instance.CreateNewBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
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