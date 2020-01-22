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
        [SerializeField]
        private TankScriptableObject playerTankScriptableObject;

        [SerializeField]
        private TankScriptableObject enemyTankScriptableObject;

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
                playerTank.TurnRight();
            }
            if(Input.GetKey(KeyCode.D))
            {
                playerTank.TurnLeft();
            }
        }

        public void CreatePlayerTank()
        {
            //creating a tank
            playerTank = new TankController(playerTankScriptableObject, Vector3.zero);
            ScreenOverlayManager.Instance.SetPlayerTankController(playerTank);
        }

        public void SpawnEnemyTank()
        {
            Vector3 randomPosition = Vector3.zero + new Vector3(Random.Range(-30,30), 0, Random.Range(-30,30));
            TankController tankBot = new TankController(enemyTankScriptableObject, randomPosition);
            tankBot.EnableBotBehaviour();
        }

        public TankController GetNearestPlayerTank(TankController tankController)
        {
            //implement the logic for multiple player tanks
            return playerTank;
        }
    }
}
