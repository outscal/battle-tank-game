using System.Collections;
using UnityEngine;

namespace BattleTank.PlayerCamera
{
    public class CameraController : MonoBehaviour
    {
        private Transform player;
        private Vector3 currentPos;

        [SerializeField] private Camera mainCamera;
        [SerializeField] private float maxCameraSize = 19f;
        [SerializeField] private float zoomOutSpeed = 0.05f;
        [SerializeField] private float offsetLevel = 0.01f;

        public void SetTankTransform(Transform _transform)
        {
            player = _transform;
            if (player != null)
                currentPos = player.position;
        }

        private void LateUpdate()
        {
            if (player != null)
            {
                transform.position += player.position - currentPos;
                currentPos = player.position;
            }
        }

        public IEnumerator ZoomOut()
        {
            while (mainCamera.orthographicSize < maxCameraSize)
            {
                mainCamera.orthographicSize += offsetLevel;
                yield return new WaitForSeconds(zoomOutSpeed);
            }
        }
    }
}
