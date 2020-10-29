using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;
    private Transform turret;
    private Transform aim;
    private void Awake()
    {
        turret = gameObject.transform;

        aim = gameObject.transform.Find("FirePoint");
    }

    private void Update()
    {
        if (joystick.pressed)
        {
           turret.rotation = Quaternion.LookRotation(new Vector3(joystick.Horizontal * 10f, 0, joystick.Vertical * 10f));
        }
      
    }
}

