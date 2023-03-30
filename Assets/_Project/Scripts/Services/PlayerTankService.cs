using UnityEngine;

namespace BattleTank
{
    public class PlayerTankService : GenericSingleton<PlayerTankService>
    {
        [SerializeField] private PlayerTankView playerTankView;
        private PlayerTankController playerTankController;

        [SerializeField] private TankScriptableObjectList tankList;
        
        private void Start()
        {
            int TankNO = Random.Range(0, tankList.tanks.Length);
            playerTankController = new PlayerTankController(new TankModel(tankList.tanks[TankNO]), playerTankView, gameObject.transform);   // Creating Tank
        }

        public Transform GetPlayerTank()
        {
            return playerTankController.GetPlayerTransform();
        }
    }
}