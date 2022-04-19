using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTankController: TankGenericSingleton<PlayerTankController>
{
    public float mSpeed = 5.0f;
    public float rSpeed = 200.0f;
    public Joystick joystick;
    void Update()
    {
        transform.Rotate(0, joystick.Horizontal * Time.deltaTime * rSpeed, 0);
        transform.Translate(0, 0, joystick.Vertical * Time.deltaTime * mSpeed);
    }

}