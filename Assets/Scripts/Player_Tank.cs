using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tank : Singleton_Generic<Player_Tank>
{
    protected Joystick joystick;

    protected override void Awake()
    {
        joystick = FindObjectOfType<Joystick>();
        base.Awake();
    }

    void Update()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.Translate(joystick.Horizontal * (Time.deltaTime * 5), 0, joystick.Vertical * (Time.deltaTime * 5));
        }
    }
}