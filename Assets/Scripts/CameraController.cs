using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    public class CameraController : MonoGenericSingletone<CameraController>
    {
        [SerializeField] private Transform target;
        [SerializeField] private float smoothSpeed = 0.005f;
        [SerializeField] private Vector3 offset = new Vector3(300, 300, 300);
        Vector3 targetPos;

        public static CameraController instance;

        private void Awake()
        {
            instance = this;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        private void LateUpdate()
        {
            Vector3 desiredposition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredposition, smoothSpeed);
            transform.position = smoothPosition;

            transform.LookAt(target);

        }

    }
}