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

            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("Generate Enemy tank");
                SpawnEnemyTank();
            }

            if(Input.GetKey(KeyCode.W))
            {
                playerTank.MoveForward();
            }
            if(Input.GetKey(KeyCode.S))
            {
                playerTank.MoveBackWard();
            }
            if(Input.GetKey(KeyCode.A))
            {
                playerTank.TurnLeft();
            }
            if(Input.GetKey(KeyCode.D))
            {
                playerTank.TurnRight();
            }
        }

        public void CreatePlayerTank()
        {
            //creating a tank
            playerTank = new TankController(tankPrefab, Vector3.zero);
        }

        public void SpawnEnemyTank()
        {
            Vector3 randomPosition = Vector3.zero + new Vector3(Random.Range(-10,10), 0, Random.Range(-10,10));
            new TankController(tankPrefab, randomPosition);
        }
    }
}
