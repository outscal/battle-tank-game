using Singleton;
using UnityEngine;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        [SerializeField]
        private GameObject tankPrefab;

        [SerializeField]
        FloatingJoystick joystick;

        public TankController CreateTank()
        {
            GameObject tankGO = GameObject.Instantiate(tankPrefab);
            TankController tankControl = tankGO.GetComponent<TankController>();
            tankControl.SetupJoystick(joystick);
            return tankControl;
        }
    }
}
