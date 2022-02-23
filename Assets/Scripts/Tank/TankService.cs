using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class TankService : SingletonMB<TankService>
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Scriptable_Object.Tank.TankList tanks;
        [SerializeField] private Transform[] enemySpawningPoints;

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
                    tankController = new PlayerTankController(joystick, tank);
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
