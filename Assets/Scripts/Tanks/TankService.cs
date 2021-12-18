using System.Collections.Generic;
using UnityEngine;
using TankSO;
using EnemyServices;

namespace TankServices
{
    public class TankService : SingletonGeneric<TankService>
    {
        public ScriptableObjectList tankList;
        public TankScriptableObjects tankScriptableObjects { get; private set; }
        //private List<TankController> tanks = new List<TankController>();
        [HideInInspector] public Transform playerPos;
        public TankView tankView { get; private set; }
        private TankController tankController;
        private List<EnemyController> enemyControllers;

        private void Start()
        {
            CreateNewTank();
        }

        private TankController CreateNewTank()
        {
            int random = Random.Range(0, tankList.tank.Length - 1);
            tankScriptableObjects = tankList.tank[random];
            tankView = tankScriptableObjects.tankView;
            TankModel tankModel = new TankModel(tankScriptableObjects);
            tankController = new TankController(tankModel, tankView);
            //tanks.Add(tankController);
            return tankController;
        }

        public TankController getTankController()
        {
            return tankController;
        }

        public void getPlayerPos(Transform _playerPos)
        {
            playerPos = _playerPos;
        }

        public Transform PlayerPos()
        {
            return playerPos;
        }

        public void destroyTank(TankController tank)
        {
            tank.destroyController();
        }

        public void destroyAllEnemies()
        {
            enemyControllers = EnemyService.Instance.enemies;
            for (int i = 0; i < enemyControllers.Count; i++)
            {
                if(EnemyService.Instance.enemies[i].enemyView != null)
                {
                    enemyControllers[i].enemyDead();
                }
            }
        }
    }
}