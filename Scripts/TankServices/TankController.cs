using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BulletServices;
using TankSO;
using BulletSO;

namespace TankServices
{
    public class TankController
    {
        public TankController(TankModel _tankModel, TankView _tankView) //constructor
        {
            tankModel = _tankModel;
            tankView = GameObject.Instantiate<TankView>(_tankView);
            CameraController.instance.SetTarget(tankView.transform);

            tankView.SetTankController(this);
            tankModel.SetTankController(this);
            tankView.ChangeColor();
        }

        public TankModel tankModel { get; }
        public TankView tankView { get; }

        public void Move(float movement, float movementSpeed)
        {
            tankView.transform.Translate(Vector3.forward * movement * movementSpeed * Time.deltaTime);
        }

        public void Rotate(float rotation, float rotateSpeed)
        {
            tankView.transform.Rotate(Vector3.up * rotation * rotateSpeed * Time.deltaTime);
        }

        public void ShootBullet()
        {
            BulletService.instance.CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }
        public Vector3 GetFiringPosition()
        {
            return tankView.BulletShootPoint.position;
        }
        public Quaternion GetFiringAngle()
        {
            return tankView.transform.rotation;
        }
        public BulletScriptableObject GetBullet()
        {
            return TankService.instance.tankScriptable.bulletType;
        }
    }
}