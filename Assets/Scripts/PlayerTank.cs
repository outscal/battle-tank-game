using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : TankSingletonGeneric<PlayerTank>
{

    public float speed;
    public Joystick joystick;

    private void Update()
    {
        transform.position += new Vector3(joystick.Horizontal*speed*Time.deltaTime, 0, joystick.Vertical*speed*Time.deltaTime);
    }

}
