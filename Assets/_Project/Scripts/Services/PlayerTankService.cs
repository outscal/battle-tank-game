using BattleTank.Enum;
using BattleTank.GenericSingleton;
using BattleTank.PlayerTank;
using BattleTank.Tank;
using BattleTank.TankSO;
using UnityEngine;

namespace BattleTank.Services
{
    public class PlayerTankService : GenericSingleton<PlayerTankService>
    {
        [SerializeField] private PlayerTankView playerTankView;
        private PlayerTankController playerTankController;

        [SerializeField] private TankScriptableObjectList tankList;

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
            
            UIService.Instance.SetPlayerHealthUI();
            playerTankController = new PlayerTankController(new TankModel(tankList.Tanks[TankNO]), playerTankView, gameObject.transform);
            GameService.Instance.StartLevel();
            CollectibleService.Instance.UpdateCollectibleTankMaterial(tankList.Tanks[TankNO].Material);
        }

        public Transform GetPlayerTank()
        {
            return playerTankController.GetPlayerTransform();
        }

        public bool GetIsPlayerTankAlive()
        {
            return playerTankController.GetIsPlayerTankALive();
        }

        public PlayerTankController GetPlayerTankController()
        {
            return playerTankController;
        }
    }
}