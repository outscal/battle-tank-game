using UnityEngine;

namespace TankBattle.Tank.PlayerTank
{
    // Player Service : function 1 : call create player tank
    // function 2 -  give controller ref to playerMove
    public class PlayerService: GenericSingleton<PlayerService>
    {

        private MoveController.TankController tankController;

        private void Start()
        {
            CreateTank();
        }

        public void CreateTank()
        {
            tankController = Tank.CreateTank.CreateTankService.Instance.CreateNewPlayerTank();
        }

        public MoveController.TankController GetTankController()
        {
            return tankController;
        }
    };
}