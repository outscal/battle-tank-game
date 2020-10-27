using Tank;
using UnityEngine;
using Player;
using ScriptableObjects;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private PlayerController playerTank;
        [SerializeField]
        private FloatingJoystick leftJoystick, rightJoystick;

        [SerializeField]
        private TankScriptableObject playerObj;

        void Start()
        {
            CreatePlayer();
        }

        void CreatePlayer()
        {
            TankController tank = TankService.Instance.CreateTank();
            tank.TankSetup(playerObj);
            playerTank = tank.gameObject.GetComponent<PlayerController>();
            playerTank.SetupJoysticks(leftJoystick, rightJoystick);
            CameraController.Instance.SetTarget(playerTank.transform);
        }
    }
}
