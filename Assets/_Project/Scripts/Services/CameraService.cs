using BattleTank.GenericSingleton;
using UnityEngine;

namespace BattleTank.Services
{
    public class CameraService : GenericSingleton<CameraService>
    {
        [SerializeField] private Camera mainCamera;
        private Vector3 cameraPositionAtDestruction;
        private Quaternion cameraRotationAtDestruction;

        private void Start()
        {
            cameraPositionAtDestruction = new Vector3(-50, 12, -3);
            cameraRotationAtDestruction = Quaternion.Euler(new Vector3(40, 90, 0));
        }
        
        public void AttachIntoPlayer(Transform playerTransform)
        {
            mainCamera.transform.SetParent(playerTransform);
            mainCamera.transform.position = new Vector3(playerTransform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        public void DetachFromPlayer()
        {
            mainCamera.transform.SetParent(null);
        }

        public void ZoomOutCamera()
        {
            mainCamera.transform.position = cameraPositionAtDestruction;
            mainCamera.transform.rotation = cameraRotationAtDestruction;
        }
    }
}