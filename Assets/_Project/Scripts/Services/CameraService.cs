using BattleTank.GenericSingleton;
using UnityEngine;

namespace BattleTank.Services
{
    public class CameraService : GenericSingleton<CameraService>
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Vector3 cameraPositionAtDestruction;
        [SerializeField] private Vector3 newRotationAtDestruction;
        [SerializeField] private Vector3 cameraPositionAtPlayer;
        [SerializeField] private Vector3 newRotationAtPlayer;
        private Quaternion cameraRotationAtDestruction;

        private void Start()
        {
            cameraRotationAtDestruction = Quaternion.Euler(newRotationAtDestruction);
        }

        public void AttachIntoPlayer(Transform playerTransform)
        {
            mainCamera.transform.SetParent(playerTransform);
            transform.position = cameraPositionAtPlayer;
            transform.rotation = Quaternion.Euler(newRotationAtPlayer);
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