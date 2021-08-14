using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankController
    {
        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
        }

        public void Fire(GameObject shell, Transform fireTransform, float m_LaunchForce)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject gameObject = GameObject.Instantiate(shell, fireTransform.position, fireTransform.rotation);
                Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
                rigidbody.velocity = m_LaunchForce * fireTransform.forward;
            }
        }

        public void Move(Transform transform, float gravity, CharacterController charController)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 moveDirection = transform.forward;
                moveDirection.y -= gravity * Time.deltaTime;

                charController.Move(moveDirection * TankModel.Speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 moveDirection = -transform.forward;
                moveDirection.y -= gravity * Time.deltaTime;

                charController.Move(moveDirection * TankModel.Speed * Time.deltaTime);
            }
        }

        public void Rotate(Transform transform, float rotateDegreesPerSecond)
        {
            Vector3 rotation_Direction = Vector3.zero;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rotation_Direction = transform.TransformDirection(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rotation_Direction = transform.TransformDirection(Vector3.right);
            }
            if (rotation_Direction != Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotation_Direction), rotateDegreesPerSecond * Time.deltaTime);
            }
        }
        public TankModel TankModel { get; }
        public TankView TankView { get; }
    }
}
