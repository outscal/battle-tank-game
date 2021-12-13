using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankServices
{
    public class TankController
    {
        private Rigidbody rb;
        public TankModel tankModel { get; private set; }
        public TankView tankView { get; private set; }

        public TankController(TankModel model, TankView tankView)
        {
            tankModel = model;
            tankView = GameObject.Instantiate<TankView>(tankView);
            CameraFollow.instance.SetTarget(tankView.transform);
            rb = tankView.GetComponent<Rigidbody>();
            tankView.SetTankController(this);
            tankModel.SetTankController(this);
        }

        //public void Move(float moveAxis, float movSpeed)
        //{
        //    Vector3 move = tankView.transform.position;
        //    move += tankView.transform.forward * moveAxis * movSpeed * Time.deltaTime;
        //    rb.MovePosition(rb.position + move);
        //}

        //public void Rotate(float rotateAxis, float rotateSpeed)
        //{
        //    float rotate = rotateAxis * rotateSpeed * Time.deltaTime;
        //    Quaternion turn = Quaternion.Euler(0f, rotate, 0f);
        //    rb.MoveRotation(rb.rotation * turn);
        //}

        //public void Shoot()
        //{
        //    BulletService.Instance.CreateBullet(GetFiringPos(), GetFiringRot(), GetBullet());
        //}

        //private Quaternion GetFiringRot()
        //{
        //    return tankView.transform.rotation;
        //}

        //private BulletScriptableObject GetBullet()
        //{
        //    return TankModel.BulletType;
        //}

        //private Vector3 GetFiringPos()
        //{
        //    return tankView.bulletShootPoint.position;
        //}
    }
}
