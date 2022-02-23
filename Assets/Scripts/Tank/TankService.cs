using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class TankService : SingletonMB<TankService>
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Scriptble_Object.Tank.Tank[] tanks;

        private List<TankController> _tankControllers = new List<TankController>();

        private void Start()
        {
            _tankControllers.Add(CreateTank(tanks[0]));
        }

        private TankController CreateTank(Scriptble_Object.Tank.Tank tank)
        {
            TankController tankController = null;
            switch (tank.TankType)
            {
                case TankType.Player :
                    tankController = new PlayerTankController(joystick, tank);
                    break;
                case TankType.Enemy:
                    tankController = new EnemyTankController(tank);
                    break;
            }

            return tankController;
        }
    }
    
}
