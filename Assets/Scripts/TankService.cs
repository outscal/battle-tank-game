using Singleton;
using UnityEngine;
using System.Collections;

namespace Tank
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        [SerializeField]
        private TankController playerTank;
        
        public TankController CreatePlayer()
        {
            TankController tankControl = Instantiate(playerTank, TankSpawnPositionManager.Instance.GetEmptySpawnPosition(), Quaternion.identity);
            TankSpawnPositionManager.Instance.AddTank(tankControl.gameObject);
            return tankControl;
        }
        
       

        public IEnumerator RespawnTankAfterDelay(TankController tank)
        {
            tank.gameObject.SetActive(false);
            yield return new WaitForSeconds(5f);
            ResetTank(tank);
        }

        public void ResetTank(TankController tank)
        {
            tank.gameObject.SetActive(true);
            tank.transform.position = TankSpawnPositionManager.Instance.GetEmptySpawnPosition();
            tank.ResetTankValues();
        }
    }
}
