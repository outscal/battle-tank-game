using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIService : GenericSingleTon<UIService>
{
    [SerializeField] private Joystick joystick;

    public float GetJoystickHorizontal() => joystick.Horizontal;
    public float GetJoystickVertical() => joystick.Vertical;

}
