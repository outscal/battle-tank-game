using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// enemy tank service
    /// </summary>
    //public class EnemyTankService : GenericMonoSingletone<EnemyTankService>
    public class EnemyTankService : MonoSingleton<EnemyTankService>
    {

        //[SerializeField] private TankView tankView;
          [SerializeField] EnemyTankScriptableObject tankConfigurations;
       // [SerializeField] private EnemyTankScriptableObjectList tankList;

        private void Start()
        {
            StartGame();
        }

        void StartGame()
        {
            CreateNewTank();
        }

        private EnemyTankController CreateNewTank()
        {
            //int randomNumber = Random.Range(0, tankList.tanks.Length);
            EnemyTankScriptableObject enemytankScriptableObject = tankConfigurations;
            //TankScriptableObject tankScriptableObject = tankList.tanks[randomNumber];
            Debug.Log("Creating Tank with Type:" + enemytankScriptableObject.TankName);

            EnemyTankModel model = new EnemyTankModel(enemytankScriptableObject);
            EnemyTankView enemyTankView = enemytankScriptableObject.EnemyTankView;
            //TankModel model = new TankModel(TankType.None, 5, 100f);
            EnemyTankController enemyTank = new EnemyTankController(model, enemyTankView);
            return enemyTank;
        }
    }
}