using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BulletServices;

namespace TankServices
{
    public class TankController
    {
        public TankController(TankModel _tankModel, TankView _tankView) //constructor
        {
            tankModel = _tankModel;
            tankView = GameObject.Instantiate<TankView>(_tankView);
            CameraController.instance.SetTarget(tankView.transform);
            //we create a controller then we spawn the view and as view 
            //can be controlled as per constraints in scriptable objects that 
            //is why we instantiate so we will use this MVC to instantiate a 3 
            //similar tank view with different properties of health , damage,etc

            //we can reference of the TankView vai Instantiating bcoz View has Mono as Parent
            // this method cannot be applied to take ref. of model.
            tankView.GetTankController(this);
            tankModel.GetTankController(this);


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
            BulletService.instance.CreateBullet(this);
        }
        public Vector3 GetFiringPosition()
        {
            return tankView.BulletShootPoint.position;
        }
        public Quaternion GetFiringAngle()
        {
            return tankView.transform.rotation;
        }
    }
}