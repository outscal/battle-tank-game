using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerTankService;
//SCRIPT USED FOR COMMUNICATION

namespace PlayerTankService
{
    public class TankService : MonoSingletonGeneric <TankService>
    {
        [SerializeField]
        private Joystick tankMovementJoystick;
        public TankScriptableObject tankScriptableObjects { get; private set; }
        public Camera cam;
        public TankView tankView { get; private set; }
        public TankScriptableObjectList tankList;
        public TankType tanktype;
        private TankController tankcontroller;
        private void Start()
        {
            /*StartGame();*/
            CreateNewTank();
            setTankJoyStick();
            tankcontroller.setCameraReference(cam);
        }
        public void setTankJoyStick()
        {
            if(tankcontroller != null)
            {
                tankcontroller.setJoysticks(tankMovementJoystick);
            }
        }
        private TankController CreateNewTank()
        {
            int random = Random.Range(0, tankList.tanks.Length);
            tankScriptableObjects = tankList.tanks[random];
            tankView = tankScriptableObjects.tankView;
            TankModel tankModel = new TankModel(tankScriptableObjects);
            tankcontroller = new TankController(tankModel, tankView);
            return tankcontroller;
        }
    }
}
