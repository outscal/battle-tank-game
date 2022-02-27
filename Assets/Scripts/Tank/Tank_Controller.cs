using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class Tank_Controller
    {
        public Tank_Model Tank_Model { get; }
        public Tank_View Tank_View { get; }
        public Tank_Controller(Tank_Model tankmodel, Tank_View tankPrefab, Joystick joystick)
        {
            Tank_Model = tankmodel;
            Tank_View = GameObject.Instantiate<Tank_View>(tankPrefab);
            Tank_View.SetTankController(this);
            Tank_View.setJoystick(joystick);
        }
        public void Tank_Movement()
        {
            if (Mathf.Abs(Tank_View.Joystick.Horizontal) > 0.2f || Mathf.Abs(Tank_View.Joystick.Vertical) > 0.2F)
            {
                Vector3 moveDirection = new Vector3(Tank_View.Joystick.Horizontal, 0, Tank_View.Joystick.Vertical);
                moveDirection.Normalize();

                Tank_View.transform.Translate(moveDirection * Tank_Model.Speed * Time.deltaTime, Space.World);
                Tank_View.transform.forward = moveDirection;
            }
        }
    }
}
