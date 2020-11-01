using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoSingeltonGeneric<TankController>
{
    [SerializeField]
    private Joystick joystick;

    internal float vertical{get;private set;}
    internal float horizontal{get;private set;}
    
//`````````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````````
    private void FixedUpdate() {

        vertical = joystick.Vertical;
        horizontal = joystick.Horizontal;
    }

}
