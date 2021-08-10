using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        private float movement, rotation;
        public Transform BulletShootPoint;
        private float canFire = 0f;
        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        void Update()
        {
            Movement();

            // if (movement != 0)
            //     tankController.MoveTank(movement, tankController.tankModel.movementSpeed);

            // if (rotation != 0)
            //     tankController.RotateTank(rotation, tankController.tankModel.rotationSpeed);
        }

        private void FixedUpdate()
        {
            // if (movement != 0)
            tankController.MoveTank(movement, tankController.tankModel.movementSpeed);

            // if (rotation != 0)
            tankController.RotateTank(rotation, tankController.tankModel.rotationSpeed);
        }

        private void Movement()
        {
            rotation = Input.GetAxisRaw("Horizontal");
            movement = Input.GetAxisRaw("Vertical");
        }

        private void ShootBullet()
        {
            if (Input.GetButtonDown("Fire1") && canFire < Time.time)
            {
                canFire = tankController.tankModel.fireRate + Time.time;
                tankController.ShootBullet();
            }
        }


    }


}//class
























//     private float rotation;
//     private float movement;
//     // private Rigidbody rigidbody;

//     private TankController tankController;
//     void Start()
//     {

//         // rigidbody = gameObject.GetComponent<Rigidbody>();
//     }

//     public void SetTankController(TankController _tankController)
//     {
//         tankController = _tankController;
//     }

//     private void Update()
//     {
//         Movement();
//     }

//     private void Movement()
//     {
//         // rotation = Input.GetAxis("Horizontal");
//         // movement = Input.GetAxis("Vertical");


//     }

//     private void FixedUpdate()
//     {
//         if (movement != 0)
//         {
//             Debug.Log("move");
//             Move(20, 20);
//         }
//         if (rotation != 0)
//         {
//             Debug.Log("rotate");
//             Rotate(20, 20);
//         }
//     }



//     public void Move(float movement, float movementSpeed)
//     {
//         Vector3 move = transform.position;
//         move += transform.forward * movement * movementSpeed * Time.fixedDeltaTime;
//         // move += transform.forward * 20 * Time.fixedDeltaTime;

//         // rigidbody.MovePosition(move);
//     }

//     public void Rotate(float rotation, float rotateSpeed)
//     {
//         Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
//         Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
//         // rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
//     }