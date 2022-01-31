using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tankServices
{


    public class PlayerTankView : TankSingeton<PlayerTankView>
    {

        private PlayerTankController playerTankController;
        public Joystick joystick;
        private float movement;
        private float turn;

        public void setController(PlayerTankController _PlayerTankController)
        {
            playerTankController = _PlayerTankController;
        }
        


        private void Update()
        {
            Movement();
        }

        private void FixedUpdate()
        {
            if (movement + turn != 0 && playerTankController!=null)
            {
               
                playerTankController.move(movement, turn);
            }
        }
        private void Movement()
        {
            turn = joystick.Horizontal;
            movement = joystick.Vertical;
        }

       
    }

   

}
