using BattleTank.EnemyTank;
using BattleTank.GenericSingleton;
using BattleTank.Tank;
using BattleTank.TankSO;
using UnityEngine;

namespace BattleTank.Services
{
    public class EnemyTankService : GenericSingleton<EnemyTankService>
    {
        [SerializeField] private EnemyTankView enemyTankView;
        private EnemyTankController enemyTankController;

        [SerializeField] private TankScriptableObjectList tankList;

        private void Start()
        {
            int TankNO = Random.Range(0, tankList.Tanks.Length);
            new EnemyTankController(new TankModel(tankList.Tanks[TankNO]), enemyTankView, gameObject.transform, PlayerTankService.Instance.GetPlayerTank());
        }
    }
}