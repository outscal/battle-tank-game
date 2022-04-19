using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]
public class TankController : SingletonGeneric<TankController>
{
     [SerializeField] private Rigidbody _rigidbody;
     [SerializeField] private FloatingJoystick _joystick;
     [SerializeField] private float _moveSpeed ;



    

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

       if  (_joystick.Horizontal != 0 || _joystick.Vertical != 0)

            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            }

    }
}
