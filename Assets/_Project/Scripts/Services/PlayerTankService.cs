using BattleTank.Enum;
using BattleTank.GenericSingleton;
using BattleTank.PlayerTank;
using BattleTank.Tank;
using BattleTank.TankSO;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.Services
{
    public class PlayerTankService : GenericSingleton<PlayerTankService>
    {
        [SerializeField] private PlayerTankView playerTankView;
        private PlayerTankController playerTankController;

        [SerializeField] private TankScriptableObjectList tankList;
        [SerializeField] private List<ColorType> colors;

        public void SpawnPlayerTank(TankType tankType)
        {
            int TankNO = 0;

            for(int i = 0; i < tankList.Tanks.Length; i++)
            {
                if(tankList.Tanks[i].TankType == tankType)
                {
                    TankNO = i;
                }
            }

            for (int i = 0; i < colors.Capacity; i++)
            {
                if (tankList.Tanks[TankNO].TankType == colors[i].tankType)
                {
                    UIService.Instance.PlayerHealthUI.SetUIColor(colors[i].backgroundColor, colors[i].foregroundColor);
                }
            }
            UIService.Instance.SetPlayerHealthUI();
            playerTankController = new PlayerTankController(new TankModel(tankList.Tanks[TankNO]), playerTankView, gameObject.transform);
            GameService.Instance.StartLevel();
        }

        public Transform GetPlayerTank()
        {
            return playerTankController.GetPlayerTransform();
        }

        public bool GetIsPlayerTankAlive()
        {
            return playerTankController.GetIsPlayerTankALive();
        }
    }
}