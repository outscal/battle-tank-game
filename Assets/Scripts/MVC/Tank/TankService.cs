using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// service class that handles all tank services
    /// and it inherits Monobehaviour class
    /// </summary>
    //public class TankService : GenericMonoSingletone<TankService>
    public class TankService : MonoSingleton<TankService>
    {
        //[SerializeField] private TankView tankView;
        //[SerializeField] TankScriptableObject[] tankConfigurations;
        [SerializeField] private TankScriptableObjectList tankList;

        private void Start()
        {
            StartGame();
        }

        void StartGame()
        {
            CreateNewTank();
        }
        private TankController CreateNewTank()
        {
            int randomNumber = Random.Range(0, tankList.tanks.Length);
            //TankScriptableObject tankScriptableObject = tankConfigurations[2];
            TankScriptableObject tankScriptableObject = tankList.tanks[randomNumber];
            Debug.Log("Creating Tank with Type:" + tankScriptableObject.TankName);

            TankModel model = new TankModel(tankScriptableObject);
            TankView tankView = tankScriptableObject.TankView;
            //TankModel model = new TankModel(TankType.None, 5, 100f);
            TankController tank = new TankController(model, tankView);
            return tank;
        }
    }
}