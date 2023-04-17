using BattleTank.GenericSingleton;
using UnityEngine;

namespace BattleTank.Services
{
    public class CameraService : GenericSingleton<CameraService>
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Vector3 cameraPositionAtDestruction;
        [SerializeField] private Vector3 newRotationAtDestruction;
        private Quaternion cameraRotationAtDestruction;
        private Vector3 cameraPositionAtStarting;
        private Vector3 cameraRotationAtStarting;

        private void Start()
        {
            cameraRotationAtDestruction = Quaternion.Euler(newRotationAtDestruction);
            cameraPositionAtStarting = transform.position;
            cameraRotationAtStarting = transform.rotation.eulerAngles;
        }

        public void AttachIntoPlayer(Transform playerTransform)
        {
            mainCamera.transform.SetParent(playerTransform);
            transform.position = cameraPositionAtStarting;
            transform.rotation = Quaternion.Euler(cameraRotationAtStarting);
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