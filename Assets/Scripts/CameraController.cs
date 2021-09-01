using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    public class CameraController : MonoGenericSingletone<CameraController>
    {
        [SerializeField] private Transform target;
        private Vector3 offset;
        [SerializeField] private float smoothFactor;
        private Transform playerLastPos;
        void FollowPlayer()
        {
            if (target != null)
            {
                Vector3 targetPosition = target.position + offset;
                //Debug.Log("pos: " + target.position);
                Vector3 smoothedposition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
                transform.position = targetPosition;
                playerLastPos = target;
            }
        }

        private void LateUpdate()
        {
            FollowPlayer();
        }

        public void SetTarget(Transform target)
        {
            if (target != null)
            {
                this.target = target;
            }
            else
            {
                target = playerLastPos;
            }
            Debug.Log("target");
        }
    }
}