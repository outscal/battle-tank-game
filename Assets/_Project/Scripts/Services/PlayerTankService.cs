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
        
        private void Start()
        {
            int TankNO = Random.Range(0, tankList.Tanks.Length);
            playerTankController = new PlayerTankController(new TankModel(tankList.Tanks[TankNO]), playerTankView, gameObject.transform);
        }

        public Transform GetPlayerTank()
        {
            return playerTankController.GetPlayerTransform();
        }
    }
}