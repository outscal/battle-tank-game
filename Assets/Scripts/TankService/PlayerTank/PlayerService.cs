using System.Collections;
using UnityEngine;

namespace TankBattle.Tank.PlayerTank
{
    // Player Service : function 1 : call create player tank
    // function 2 -  give controller ref to playerMove
    public class PlayerService: GenericSingleton<PlayerService>
    {
        [SerializeField] private Transform spawnPoint;

        private int playerTankIndex = 0;
        private TankController tankController;

        private void Start()
        {
            CreateTank();
        }

        public void CreateTank()
        {
            tankController = Tank.CreateTank.CreateTankService.Instance.CreateTank(spawnPoint.position, playerTankIndex);
        }

        public TankController GetTankController()
        {
            return tankController;
        }
    };
}