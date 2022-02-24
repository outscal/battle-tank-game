using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Tank
{
    public class TankService : SingletonMB<TankService>
    {
        [SerializeField] private InputSystem.InputSystem inputSystem;
        [SerializeField] private Scriptable_Object.Tank.TankList tanks;
        [SerializeField] private Transform[] enemySpawningPoints;
        [SerializeField] private NavMeshData navMeshData;

        public NavMeshData NavMeshData => navMeshData;

        private List<TankController> _tankControllers = new List<TankController>();

        private void Start()
        {
            for (int i = 0; i < tanks.List.Length; i++)
            {
                _tankControllers.Add(CreateTank(tanks.List[i]));
            }
        }

        private TankController CreateTank(Scriptable_Object.Tank.Tank tank)
        {
            TankController tankController = null;
            switch (tank.TankType)
            {
                case TankType.Player :
                    tankController = new PlayerTankController(inputSystem, tank);
                    break;
                case TankType.Enemy:
                    tankController = new EnemyTankController(tank,GetRandomPosition());
                    break;
            }

            return tankController;
        }

        private Vector3 GetRandomPosition()
        {
            return enemySpawningPoints[Random.Range(0, enemySpawningPoints.Length - 1)].position;
        }
    }
    
}
