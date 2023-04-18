using BattleTank.EnemyTank;
using BattleTank.GenericSingleton;
using BattleTank.Tank;
using BattleTank.TankSO;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.Services
{
    public class EnemyTankService : GenericSingleton<EnemyTankService>
    {
        [SerializeField] private EnemyTankView enemyTankView;
        private EnemyTankController enemyTankController;
        [SerializeField] private TankScriptableObjectList tankList;
        [SerializeField] private List<GameObject> spawnPositions;
        private List<EnemyTankController> enemyTankControllersList;
        [SerializeField] private List<ColorType> colors;

        private void Start()
        {
            enemyTankControllersList = new List<EnemyTankController>();

            for (int i = 0; i < spawnPositions.Count; i++)
            {
                int TankNO = Random.Range(0, tankList.Tanks.Length);
                
                EnemyTankController enemyTankController = new EnemyTankController(new TankModel(tankList.Tanks[TankNO]), enemyTankView, spawnPositions[i].transform, PlayerTankService.Instance.GetPlayerTank(), colors);
                enemyTankControllersList.Add(enemyTankController);
            }
        }

        public List<EnemyTankController> GetEnemyTankControllersList()
        {
            return enemyTankControllersList;
        }
    }
}