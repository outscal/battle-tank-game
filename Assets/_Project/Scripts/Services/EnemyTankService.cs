using UnityEngine;

namespace BattleTank
{
    public class EnemyTankService : GenericSingleton<EnemyTankService>
    {
        [SerializeField] private EnemyTankView enemyTankView;
        private EnemyTankController enemyTankController;

        [SerializeField] private TankScriptableObjectList tankList;

        private void Start()
        {
            int TankNO = Random.Range(0, tankList.tanks.Length);
            new EnemyTankController(new TankModel(tankList.tanks[TankNO]), enemyTankView, gameObject.transform, PlayerTankService.Instance.GetPlayerTank());   // Creating Tank
        }
    }
}