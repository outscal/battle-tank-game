using BattleTank.GenericSingleton;
using UnityEngine;

namespace BattleTank.Services
{
    public class CameraService : GenericSingleton<CameraService>
    {
        [SerializeField] private Camera mainCamera;

        public void AttachIntoPlayer(Transform playerTransform)
        {
            mainCamera.transform.SetParent(playerTransform);
            mainCamera.transform.position = new Vector3(playerTransform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        public void DetachFromPlayer()
        {
            mainCamera.transform.SetParent(null);
        }
    }
}