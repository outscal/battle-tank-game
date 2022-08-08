using GlobalServices;
using System.Collections.Generic;
using TankSO;
using UnityEngine;

namespace PlayerTankServices
{
    // Handles spawning of player tank and communication of player tank service with other services.
    public class PlayerTankService : MonoSingletonGeneric<PlayerTankService>
    {
        public PlayerTankView playerTankView;

        public TankSOList playerTankList; // Player tank scriptable objects list.

        // Reference of joystick for getting inputs.
        public Joystick rightJoystick;
        public Joystick leftJoystick;

        private PlayerTankController tankController;

        // Stores controllers of all active player tanks in the scene.
        private List<PlayerTankController> playerTanks = new List<PlayerTankController>();
        private TankType playerTankType;

        private void Start()
        {
            // To spawn random type of player tank.
            playerTankType = (TankType) Random.Range(0, playerTankList.tanks.Length);
        
            tankController = CreatePlayerTank(playerTankType);
            playerTankView = tankController.tankView;           
        
            SetPlayerTankControlReferences();
        }

        private void Update()
        {
            // For input detection in tank controller.
            if (tankController != null)
            {
                tankController.UpdateTankController();
            }
        }

        private void FixedUpdate()
        {
            // For physics calculation in tank controller.
            if(tankController != null)
            {
                tankController.FixedUpdateTankController();
            }
        }

        // Spawns specified type of player tank and returns tank controller. 
        private PlayerTankController CreatePlayerTank(TankType tanktype)
        {
            // To search for sciptable object which holds data of specified player tank.
            foreach (TankScriptableObject tank in playerTankList.tanks)
            {
                if (tank.tankType == playerTankType)
                {
                    PlayerTankModel tankModel = new PlayerTankModel(tank);
                    PlayerTankController tankController = new PlayerTankController(tankModel, playerTankView);
                    playerTanks.Add(tankController);
                    return tankController;
                }
            }
            return null;   
        }

        // Sets references of joystick in tank controller.
        private void SetPlayerTankControlReferences()
        {
            if(tankController != null)
            {
                tankController.SetJoystickReference(rightJoystick, leftJoystick);
            }
        }

        // Returns tank controller at specified index from player tank controller list.
        public PlayerTankController GetTankController(int index = 0) 
        {
            return playerTanks[index];
        }

        // Removes specified tank controller from the tank controller list.
        public void DestroyTank(PlayerTankController tank)
        {
            for (int i = 0; i < playerTanks.Count; i++)
            {
                if (playerTanks[i] == tank)
                {
                    playerTanks[i] = null;
                    playerTanks.Remove(tank);
                }
            }

            EventService.Instance.InvokeOnGameOverEvent();
        }

        // Enables all the player tanks from tank controller list when the game is resumed.
        public void TurnONTanks()
        {
            for (int i = 0; i < playerTanks.Count; i++)
            {
                if (playerTanks[i] != null)
                {
                    if (playerTanks[i].tankView)  playerTanks[i].tankView.gameObject.SetActive(true);

                }
            }
        }

        // Disables all the player tanks from tank controller list when the game is paused.
        public void TurnOFFTanks()
        {
            for (int i = 0; i < playerTanks.Count; i++)
            {
                if (playerTanks[i] != null)
                {
                    if (playerTanks[i].tankView)  playerTanks[i].tankView.gameObject.SetActive(false);
                }
            }
        }
    }
}
