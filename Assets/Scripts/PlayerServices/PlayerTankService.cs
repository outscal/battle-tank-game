using GlobalServices;
using TankSO;
using UnityEngine;

namespace PlayerTankServices
{
    public class PlayerTankService : MonoSingletonGeneric<PlayerTankService>
    {
        [HideInInspector] public PlayerTankView playerTankView;

        public TankSOList playerTankList;
        public Joystick rightJoystick;
        public Joystick leftJoystick;
        public Camera camera;

        private PlayerTankController tankController;
        private TankType playerTankType;

        private void Start()
        {
            playerTankType = (TankType) Mathf.Floor(Random.Range(0, 2.5f));
        
            tankController = CreatePlayerTank(playerTankType);
            playerTankView = tankController.tankView;

            SetPlayerTankControlReferences();
        }

        private void Update()
        {
            if (tankController != null)
            {
                tankController.UpdateTankController();
            }
        }

        private void FixedUpdate()
        {
            if(tankController != null)
            {
                tankController.FixedUpdateTankController();
            }
        }

        private PlayerTankController CreatePlayerTank(TankType tanktype)
        {
            foreach (TankScriptableObject tank in playerTankList.tanks)
            {
                if (tank.tankType == playerTankType)
                {
                    PlayerTankModel tankModel = new PlayerTankModel(playerTankList.tanks[(int)tanktype].health,
                                                                    playerTankList.tanks[(int)tanktype].movementSpeed,
                                                                    playerTankList.tanks[(int)tanktype].rotationSpeed,
                                                                    playerTankList.tanks[(int)tanktype].turretRotationRate,
                                                                    playerTankList.tanks[(int)tanktype].bulletType,
                                                                    playerTankList.tanks[(int)tanktype].maxLaunchForce,
                                                                    playerTankList.tanks[(int)tanktype].minLaunchForce,
                                                                    playerTankList.tanks[(int)tanktype].maxChargeTime);

                    PlayerTankController tankController = new PlayerTankController(tankModel, playerTankList.tanks[(int)tanktype].tankView);
                    return tankController;
                }
            }
            return null;   
        }

        private void SetPlayerTankControlReferences()
        {
            if(tankController != null)
            {
                tankController.SetJoystickReference(rightJoystick, leftJoystick);
                tankController.SetCameraReference(camera);
            }
        }
    }
}
