using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// this class instantiates the tank model in game
    /// </summary>
    public class TankController
    {
        private Rigidbody rigidbody;
        public TankModel TankModel { get; private set; }
        public TankView TankView { get; private set; }
        private EnemyTankController enemyTankController;
        private DestroyGround destroyGround;
        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            TankModel = tankModel;
            if (tankPrefab != null)
            {
                TankView = GameObject.Instantiate<TankView>(tankPrefab);
            }
            rigidbody = TankView.GetComponent<Rigidbody>();
            TankView.SetTankController(this);
            TankModel.SetTankController(this);
            CameraController.Instance.SetTarget(TankView.transform);
            Debug.Log(TankView);
        }

        //tank movement
        public void TankMovement(float movement,int speed)
        {
            Vector3 mov = TankView.transform.position;
            mov += movement * speed * Time.deltaTime * TankView.transform.forward;
            rigidbody.MovePosition(mov);
                                                                                                                                                                                                                                                                                                                                                                                                                       
            TankService.Instance.GetPlayerPos(TankView.transform);
        }

        //tank rotation
        public void TankRotation(float rotation ,float rotationSpeed)
        {
            Vector3 vector = new Vector3(0f, rotation * TankModel.rotationSpeed, 0f);
            Quaternion angle = Quaternion.Euler(vector * Time.fixedDeltaTime);
            rigidbody.MoveRotation(angle * rigidbody.rotation);
        }
        
        //tank shooting
        public void ShootBullet()
        {
             BulletService.Instance.CreateNewBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }
        //player tank will take damage 
        public void ApplyDamage(int damage)
        {
            TankModel.Health-=damage;
            if (TankModel.Health <= 0)
            {
                Dead();
            }
        }
        //triggers when player dead
        public void Dead()
        {
            TankService.Instance.DestroyTank(this);
        }
        //destroy tank model and view also after player death
        public void DestroyController()
        {
            TankModel.DestroyModel();
            TankView.DestroyView();
            TankModel = null;
            TankView = null;
            rigidbody = null;
        }

        //returning bullet firing position
        public Vector3 GetFiringPosition()
        {
            return TankView.BulletShootPoint.position;
        }

        //returning firing angle
        public Quaternion GetFiringAngle()
        {
            return TankView.transform.rotation;
        }

        //returning bullet scriptable object
        public BulletScriptableObject GetBullet()
        {
            return TankModel.bulletType;
        }

        //returning current position of tank
        public Vector3 GetCurrentTankPosition()
        {
            return TankView.transform.position;
        }
    }
}