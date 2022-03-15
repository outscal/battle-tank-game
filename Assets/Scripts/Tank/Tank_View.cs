using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class Tank_View : MonoBehaviour
    {
        // public Tank_Types TankType;
        private Tank_Controller _tankController;
        public Tank_Controller Tank_Cotroller => _tankController;
        public void SetTankController(Tank_Controller tankController) => _tankController = tankController;
        private Joystick joystick;
        public void setJoystick(Joystick joystick) => this.joystick = joystick;
        public Joystick Joystick => joystick;
        private void Update()
        {
            _tankController.Tank_Movement();
        }
    }
}