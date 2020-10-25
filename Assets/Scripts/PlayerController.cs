using Tank;
using UnityEngine;

namespace Player
{
    public class PlayerController : TankController
    {
        private FloatingJoystick leftJoystick, rightJoystick;
        private float horizontalInputLeft, verticalInputLeft, horizontalInputRight, verticalInputRight;

        public void SetupJoysticks(FloatingJoystick leftjs, FloatingJoystick rightjs)
        {
            leftJoystick = leftjs;
            rightJoystick = rightjs;
        }

        private void FixedUpdate()
        {
            HandlePlayerInput();
        }

        private void Update()
        {
            HandleJoystickInput();
        }
        
        void HandlePlayerInput()
        {
            if (horizontalInputLeft != 0 || verticalInputLeft != 0)
            {
                MoveTankForward();
            }

        }

        void HandleJoystickInput()
        {
            horizontalInputLeft = leftJoystick.Horizontal;
            verticalInputLeft = leftJoystick.Vertical;
            if (horizontalInputLeft != 0 || verticalInputLeft != 0)
            {
                chassis.transform.localEulerAngles = new Vector3(0, (Mathf.Atan2(horizontalInputLeft, verticalInputLeft) * Mathf.Rad2Deg) + 45f, 0);
            }
            horizontalInputRight = rightJoystick.Horizontal;
            verticalInputRight = rightJoystick.Vertical;
            if (horizontalInputRight != 0 || verticalInputRight != 0)
            {
                turret.transform.localEulerAngles = new Vector3(0, (Mathf.Atan2(horizontalInputRight, verticalInputRight) * Mathf.Rad2Deg) + 45f, 0);
            }
          
        }

    }
}
