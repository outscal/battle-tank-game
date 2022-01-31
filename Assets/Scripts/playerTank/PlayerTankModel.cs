using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tankServices
{
    public class PlayerTankModel
    {
        private PlayerTankController playerTankController;

        //Movement Related 
        public float movementSpeed  { get; private set; }
        public float rotationSpeed { get; private set; }

        public void SetController(PlayerTankController _PlayerTankConroller)
        {
            playerTankController = _PlayerTankConroller;
        }
        public PlayerTankModel()
        {
            movementSpeed = 10;
        }
    }
}