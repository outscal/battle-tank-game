using BattleTank.PlayerTank;
using UnityEngine;

namespace BattleTank.camera
{
    public class CameraService : MonoSingletonGeneric<CameraService>
    {
        public Camera cam;

        private void Start()
        {
            CameraSetup();
        }

        public void CameraSetup()
        {
            cam.transform.SetParent(TankService.Instance.TankController.TankView.transform);
            cam.transform.position = new Vector3(0f, 8.1f, -13f);
            cam.transform.eulerAngles = new Vector3(15f, 0f, 0f);
        }
    }
}