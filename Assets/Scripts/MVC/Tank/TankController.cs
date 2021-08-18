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

        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
            rigidbody = TankView.GetComponent<Rigidbody>();
            TankView.SetTankController(this);
            TankModel.SetTankController(this);
        }

        //tank movement
        public void TankMovement(float movement)
        {
            Vector3 mov = TankView.transform.position;
            mov += movement * TankModel.Speed * Time.deltaTime * TankView.transform.forward;
            rigidbody.MovePosition(mov);
            TankService.Instance.GetPlayerPos(TankView.transform);
        }

        //tank rotation
        public void TankRotation(float rotation)
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