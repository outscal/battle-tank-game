using System.Collections.Generic;
using TankScriptableObjects;
using TankSOList;
using UnityEngine;

/// <summary>
/// This Class is respponsible to Create, Destroy and Manage all the Tank MVCs in the Game.
/// </summary>

namespace TankServices
{
    public class TankService : GenericSingleton<TankService>
    {
        //Refernces.
        [SerializeField] private Joystick leftJoystick;

        // Player tank scriptable objects list
        public TankScriptableObjectList playerTankList;

        public TankController tankController;
        public TankView playerTankView;

        // Stores controllers of all active player tanks in the scene.
        private List<TankController> playerTanks = new List<TankController>();
        private TankType playerTankType;

        private void Start()
        {
            // To spawn random type of player tank.
            playerTankType = (TankType)Random.Range(0, playerTankList.tankScriptableObject.Length);
            Debug.Log("playerTankType : " + playerTankType);

            tankController = CreateNewPlayerTank(playerTankType);
            playerTankView = tankController.tankView;
            SetPlayerTankControlReferences();
        }

        private void FixedUpdate()
        {
            // For physics calculation in tank controller.
            if (tankController != null)
            {
                tankController.UpdateTankController();
            }
        }

        // Spawns specified type of player tank and returns tank controller. 
        private TankController CreateNewPlayerTank(TankType tankType)
        {
            // To search for sciptable object which holds data of specified player tank.
            foreach(TankScriptableObject tankSO in playerTankList.tankScriptableObject)
            {
                if (tankSO.tankType == playerTankType)
                {
                    TankModel tankModel = new TankModel(tankSO);
                    TankController tankController = new TankController(tankModel, playerTankView);
                    playerTanks.Add(tankController);
                    return tankController;
                }
            }
            return null;
        }

        // Sets references of joystick in tank controller.
        private void SetPlayerTankControlReferences()
        {
            if (tankController != null)
            {
                tankController.SetJoystickReference(leftJoystick);
            }
        }
    }
}
