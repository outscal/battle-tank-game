using Singleton;
using UnityEngine;
using System.Collections;

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
        
        public void RespawnPlayer(TankController tank)
        {
            StartCoroutine(RespawnTankAfterDelay(tank));
        }

        private IEnumerator RespawnTankAfterDelay(TankController tank)
        {
            tank.gameObject.SetActive(false);
            yield return new WaitForSeconds(5f);
            ResetTank(tank);
        }

        void ResetTank(TankController tank)
        {
            tank.gameObject.SetActive(true);
            tank.ResetTankValues();
        }
    }
}
