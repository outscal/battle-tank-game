using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Tank Movement")]
        private float _horizontalMove ;
        private float _verticalMove ;
        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private float _verticalSpeed;

        [Header("Joystick Reference")]
        [SerializeField] private Joystick _joystick;

        [Header("Components Reference")]
        [SerializeField] private Rigidbody _rb;

        private void Update()
        {
            PlayerInput();
            PlayerMovements();
        }

        private void PlayerInput()
        {
            _verticalMove = Input.GetAxis("Vertical1");
            _horizontalMove = Input.GetAxis("Horizontal1");
        }

        private void Move(float movement, float movementSpeed)
        {
            _verticalMove = Input.GetAxis("Vertical");
            _rb.velocity = transform.forward * movement * movementSpeed;
        }

        private void Rotate(float rotate , float rotateSpeed)
        {
            _horizontalMove = Input.GetAxis("Horizontal");

            Vector3 vector = new Vector3(0f, rotate * rotateSpeed, 0f);
            Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
            _rb.MoveRotation(_rb.rotation * deltaRotation);
        }

        private void PlayerMovements()
        {
            if(_verticalMove != 0 )
            {
                Move(_verticalMove, _verticalSpeed);
                Debug.Log("Vertical");
            }

            if(_horizontalMove != 0)
            {
                Rotate(_horizontalMove, _horizontalSpeed);
                Debug.Log("Horizontal");
            }
        }
    }
}