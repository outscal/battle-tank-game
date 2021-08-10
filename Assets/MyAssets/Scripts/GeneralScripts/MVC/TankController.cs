using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattaleTank
{
    public class TankController
    {

        public TankView TankView { get; private set; }
        public TankModel TankModel { get; private set; }
        // private Rigidbody rigidbody;
        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
            // rigidbody = TankView.GetComponent<Rigidbody>();
            TankView.SetTankController(this);
            tankModel.SetTankController(this);
        }


        // public void Move(float movement, float movementSpeed)
        // {
        //     Vector3 move = TankView.transform.transform.position += TankView.transform.forward * movement * movementSpeed * Time.fixedDeltaTime;
        //     rigidbody.MovePosition(move);
        // }

        // public void Rotate(float rotation, float rotateSpeed)
        // {
        //     Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
        //     Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
        //     rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        // }
    }


}