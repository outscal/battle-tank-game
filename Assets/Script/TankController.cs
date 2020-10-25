using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoSingeltonGeneric<TankController>
{
    [SerializeField]
    private float _moveForce;

    private float vertical;
    private float horizontal;
    
//`````````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````````
    private void FixedUpdate() {

        vertical = Input.GetAxis("VerticalUI");
        horizontal = Input.GetAxis("HorizontalUI");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        
        if(movement != Vector3.zero){
            transform.rotation =Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement),0.05f);
        }

        transform.Translate(_moveForce*horizontal*Time.deltaTime,0f,_moveForce*vertical*Time.deltaTime,Space.World);
    }

}
