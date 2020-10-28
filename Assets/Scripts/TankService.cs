using Singleton;
using UnityEngine;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        [SerializeField]
        private GameObject playerTankPrefab;
        
        public TankController CreatePlayer()
        {
            GameObject tankGameObject = GameObject.Instantiate(playerTankPrefab);
            TankController tankControl = tankGameObject.GetComponent<TankController>();
            return tankControl;
        }
        
    }
}
