using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Tank
{
    public class PlayerTankService : SingletonMB<PlayerTankService>, ITankService
    {
        [SerializeField] private int index;
        [SerializeField] private InputSystem.InputSystem inputSystem;
        [SerializeField] private Scriptable_Object.Tank.PlayerTankList tanks;

        private PlayerTankController _player;
        public PlayerTankController Player => _player;

        private void Start()
        {
            _player = (PlayerTankController) ((ITankService) this).CreateTank(tanks.List[index]);
        }

        TankController ITankService.CreateTank(Scriptable_Object.Tank.Tank tank)
        {
            return new PlayerTankController(inputSystem, tank);
        }

        public void Destroy(TankController controller=null)
        {
            _player = null;
        }
    }
}
