using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattaleTank
{
    public class TankView : MonoBehaviour
    {
        private float rotation;
        private float movement;

        private TankController tankController;

        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        // private void Update()
        // {
        //     // Movement();
        // }

        private void Movement()
        {
            rotation = Input.GetAxis("Horizontal");
            movement = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            // if (movement != 0)
            // {
            //     tankController.Move(movement, tankController.tankModel.movementSpeed);
            // }
            // if (rotation != 0)
            // {
            //     tankController.Rotate(rotation, tankController.tankModel.roatationSpeed);
            // }
        }



    }
}