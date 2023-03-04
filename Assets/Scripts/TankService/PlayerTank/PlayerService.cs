using UnityEngine;

namespace TankBattle.TankService.PlayerTank
{

    // generic solving problem of assigning correct ref
    // inside tankMovementService

    // temporary file for creating player tank from
    // Player Service : function 1 : create player tank
    public class PlayerService: GenericSingleton<PlayerService>
    {
        //create a player tank and assign tank controller to tank movement service
        [SerializeField] private TankType.TankType tankType;

        private MoveService.TankController tankController;

        private void Start()
        {
            CreateTank();
        }

        public void CreateTank()
        {
            tankController = TankService.Instance.CreateNewPlayerTank((int)tankType);
        }

        public MoveService.TankController GetTankController()
        {
            return tankController;
        }
    };
}