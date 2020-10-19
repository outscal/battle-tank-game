using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoSingeltonGeneric<TankController>
{
    private Rigidbody _rigidBody;

    [SerializeField]
    private float _moveForce;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {

        if(Input.GetKey(KeyCode.W)){
            _rigidBody.AddForce(_moveForce*Vector3.forward);
        }

        if(Input.GetKey(KeyCode.S)){
            _rigidBody.AddForce(_moveForce*-Vector3.forward);
        }
        
        if(Input.GetKey(KeyCode.A)){
            _rigidBody.AddForce(_moveForce*-Vector3.right);
        }
        
        if(Input.GetKey(KeyCode.D)){
            _rigidBody.AddForce(_moveForce*Vector3.right);
        }
        

    }

}
