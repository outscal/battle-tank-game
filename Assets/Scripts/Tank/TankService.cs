using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    public enum TankType
    {
        RedTank = 0,
        BlueTank = 1
    }

    public class TankService : GenericMonoSingleton<TankService>
    {
        public TankView tankPrefab;

        private TankController playerTank;

        void Start()
        {
            CreatePlayerTank();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                playerTank.FireBullet();
            }
        }

        public void CreatePlayerTank()
        {
            //creating a tank
            playerTank = new TankController(tankPrefab);
        }
    }
}
