using Singleton;
using UnityEngine;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        [SerializeField]
        private GameObject tankPrefab;
        
        public TankController CreateTank()
        {
            GameObject tankGameObject = GameObject.Instantiate(tankPrefab);
            TankController tankControl = tankGameObject.GetComponent<TankController>();
            return tankControl;
        }
    }
}
