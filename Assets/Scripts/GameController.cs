using Tank;
using UnityEngine;
using Player;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private PlayerController playerTank;
        [SerializeField]
        private FloatingJoystick leftJoystick, rightJoystick;

        void Start()
        {
            CreatePlayer();
        }

        void CreatePlayer()
        {
            TankController tank = TankService.Instance.CreateTank();
            playerTank = tank.gameObject.GetComponent<PlayerController>();
            playerTank.SetupJoysticks(leftJoystick, rightJoystick);
            CameraController.Instance.SetTarget(playerTank.transform);
        }
    }
}
