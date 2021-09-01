using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// service class that handles all tank services
    /// and it inherits Monobehaviour class
    /// </summary>
    public class TankService : MonoGenericSingletone<TankService>
    {
        public TankScriptableObjectList tankList;
        public TankScriptableObject TankScriptableObject { get; private set; }
        public TankView TankView { get; private set; }
        private List<TankController> tanks = new List<TankController>();
        private List<EnemyTankController> enemyControllers;
        private TankController tankController;
        private Transform pos;
        public GameObject destroyGround;
        int randomNo;

        private void Start()
        {
            CreateNewTank();
        }

        private TankController CreateNewTank()
        {
            randomNo = Random.Range(0, tankList.tanks.Length);
            TankScriptableObject tankScriptableObject = tankList.tanks[randomNo];
            TankView = tankScriptableObject.TankView;
            TankModel tankModel = new TankModel(tankScriptableObject);
            tankController = new TankController(tankModel, TankView);
            tanks.Add(tankController);
            return tankController;
        }

        public TankController GetTankController()
        {
            return tankController;
        }
        public void GetPlayerPos(Transform _position)
        {
            pos = _position;
        }
        //return player position to the caller
        public Transform PlayerPos()
        {
            return pos;
        }
        //destroy child components of tank after 
        public void DestroyTank(TankController tank)
        {
            DestroyAllEnemies();
            tank.DestroyController();
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i] == tank)
                {
                    tanks[i] = null;
                    tanks.Remove(tank);
                }
            }
           // destroyGround.SetActive(false);   
        }
        //destroy all enmies present in scene after players death
        async void DestroyAllEnemies()
        {
            enemyControllers = EnemyTankService.Instance.enemyTanksList;

            for (int i = 0; i < enemyControllers.Count; i++)
            {
                if (EnemyTankService.Instance.enemyTanksList[i].enemyTankView != null)
                {
                    await new WaitForSeconds(2f);
                    enemyControllers[i].DeadEnemy();
                }
            }

        }
    }
}