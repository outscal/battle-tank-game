using BulletSO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tanks
{

    public class TankService : SingletonGeneric<TankService>
    {
        public Camera Camera;
        public TankView tankView;
        public TankScriptableObjectList tankList;
        public BulletSOList bulletList;
        public Joystick RightJoystick;
        public Joystick LeftJoystick;
        public TankController tankController;
        internal static readonly object Instance;
        private ServicePoolTank ServicePoolTank;
        private void Start()
        {
            StartGame();
        }
        public void StartGame()
        {
            tankController = CreateTank();
            tankController.SetJoystick(RightJoystick, LeftJoystick);
            tankController.SetCamera(Camera);
            tankController.SetHealthUI();
        }
        IEnumerator ReturnTank(TankController tankController)
        {
            yield return new WaitForSeconds(5f);
            ServicePoolTank.ReturnItem(tankController);
        }

        public TankController CreateTank()
        {
            TankScriptableObject tankScriptableObject = tankList.tanks[1];
            TankModel model = new TankModel(tankScriptableObject);
            TankController tank = new TankController(model, tankView);
            tank.TankView.SetTankControllerReference(tank);
            return tank;
        }

    }
}
