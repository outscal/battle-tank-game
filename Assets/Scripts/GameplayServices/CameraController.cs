using System.Collections.Generic;
using GlobalServices;
using System;
using UnityEngine;
using PlayerTankServices;

namespace GameplayServices
{
    public class CameraController : MonoSingletonGeneric<CameraController>
    {
        private List<Transform> targets = new List<Transform>();

        [SerializeField] private Transform[] endTargets = new Transform[2];

        [SerializeField] private float dampTime = 0.2f;
        [SerializeField] private float screenEdgeBuffer = 4f;
        [SerializeField] private float MinSize = 6.5f;

        private Camera mainCamera;
        private float originalDampTime;
        private float zoomSpeed;
        private Vector3 moveVelocity;
        private Vector3 desiredPosition;

        protected override void Awake()
        {
            base.Awake();
            mainCamera = GetComponentInChildren<Camera>();
            originalDampTime = dampTime;
        }

        private void FixedUpdate()
        {
            Move();
            Zoom();
        }

        private void Move()
        {
            FindAveragePosition();
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);
        }

        private void FindAveragePosition()
        {
            Vector3 averagePos = new Vector3();
            int numTargets = 0;

            for (int i = 0; i < targets.Count; i++)
            {
                if (!targets[i].gameObject.activeSelf)
                {
                    continue;
                }

                averagePos += targets[i].position;
                numTargets++;
            }

            if (numTargets > 0)
            {
                averagePos /= numTargets;
            }

            averagePos.y = transform.position.y;
            desiredPosition = averagePos;
        }

        private void Zoom()
        {
            float requiredSize = FindRequiredSize();
            mainCamera.orthographicSize = Mathf.SmoothDamp(mainCamera.orthographicSize, requiredSize, ref zoomSpeed, dampTime);
        }

        private float FindRequiredSize()
        {
            Vector3 desiredLocalPosition = transform.InverseTransformPoint(desiredPosition);
            float size = 0f;

            for (int i = 0; i < targets.Count; i++)
            {
                if (!targets[i].gameObject.activeSelf)
                {
                    continue;
                }

                Vector3 targetLocalPosition = transform.InverseTransformPoint(targets[i].position);
                Vector3 desiredPositionToTarget = targetLocalPosition - desiredLocalPosition;

                size = Math.Max(size, Mathf.Abs(desiredPositionToTarget.y));
                size = Mathf.Max(size, Mathf.Abs(desiredPositionToTarget.x) / mainCamera.aspect);
            }

            size += screenEdgeBuffer;
            size = Mathf.Max(size, MinSize);

            return size;
        }

        public void SetStartPositionAndSize()
        {
            FindAveragePosition();

            transform.position = desiredPosition;
            mainCamera.orthographicSize = FindRequiredSize();
        }

        public void AddCameraTargetPosition(Transform target)
        {
            targets.Add(target);
        }

        public void RemoveCameraTargetPosition(Transform target)
        {
            targets.Remove(target);
        }

        public void SetCameraWithEndTargets()
        {
            for (int i = 0; i < endTargets.Length; i++)
            {
                targets.Add(endTargets[i]);
                dampTime = 2.5f;
            }
        }

        public void RemoveCameraEndTargets()
        {
            for (int i = 0; i < endTargets.Length; i++)
            {
                targets.Remove(endTargets[i]);
                dampTime = originalDampTime;
            }
        }
    }
}
