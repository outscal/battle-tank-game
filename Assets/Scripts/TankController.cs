using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// In MVC there won't be any script is Singleton, rather than that MVC-S the S mean service which controlls total MVC will be a Singleton
// This need to be Tank Controller
// Tank View will be attached to the Game Object and Tank controller will be called in the Tank View
// Like Tank View there will be Tank Model which will be Monobehaviour(as it should contain Unity Engine header coz it uses some services of it) but not attached to any Game Object 
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