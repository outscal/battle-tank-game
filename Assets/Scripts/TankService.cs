using Singleton;
using UnityEngine;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        [SerializeField]
        private GameObject tankPrefab;

        [SerializeField]
        private FloatingJoystick joystick;

        public TankController CreateTank()
        {
            GameObject tankGameObject = GameObject.Instantiate(tankPrefab);
            TankController tankControl = tankGameObject.GetComponent<TankController>();
            tankControl.SetupJoystick(joystick);
            return tankControl;
        }
    }
}
