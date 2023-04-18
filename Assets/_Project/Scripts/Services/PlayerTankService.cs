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
        
        private void Start()
        {
            int TankNO = UnityEngine.Random.Range(0, tankList.Tanks.Length);

            for (int i = 0; i < colors.Capacity; i++)
            {
                if(tankList.Tanks[TankNO].TankType == colors[i].tankType)
                {
                    UIService.Instance.PlayerHealthUI.SetUIColor(colors[i].backgroundColor, colors[i].foregroundColor);
                }
            }

            playerTankController = new PlayerTankController(new TankModel(tankList.Tanks[TankNO]), playerTankView, gameObject.transform);
        }

        public Transform GetPlayerTank()
        {
            return playerTankController.GetPlayerTransform();
        }

    }
}