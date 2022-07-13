using System.Collections.Generic;
using GlobalServices;
using System;
using UnityEngine;

namespace GameplayServices
{
    // Handles camera position and orthographic size.
    public class CameraController : MonoSingletonGeneric<CameraController>
    {
        // Stores all active tank transforms.
        private List<Transform> targets = new List<Transform>();

        [SerializeField] private float dampTime = 0.2f; 
        [SerializeField] private float targetAdditionDampTime = 1.5f; // Damp time when new target is added.
        [SerializeField] private float screenEdgeBuffer = 4f; 
        [SerializeField] private float MinSize = 6.5f; // Minimum orthographic size.
        [SerializeField] private float MaxSize = 10f; // Maximum orthographic size.

        private Camera camera;

        private float originalDampTime;
        private float zoomSpeed;
        private float gameOverCameraOrthographicSize = 20f;

        private Vector3 gameOverCameraPostion = new Vector3(6, 8.5f, 0);
        private Vector3 moveVelocity;
        private Vector3 desiredPosition;

        private bool b_IsGameOver;
        private bool b_IsMove;

        protected override void Awake()
        {
            base.Awake();

            camera = GetComponentInChildren<Camera>();
            originalDampTime = dampTime;
            b_IsGameOver = false;
            b_IsMove = true;
        }

        private void OnEnable()
        {
            EventService.Instance.OnGameOver += GameOver;
            EventService.Instance.OnGamePaused += GamePaused;
            EventService.Instance.OnGameResumed += GameResumed;
        }

        private void OnDisable()
        {
            EventService.Instance.OnGameOver -= GameOver;
            EventService.Instance.OnGamePaused -= GamePaused;
            EventService.Instance.OnGameResumed -= GameResumed;
        }

        private void FixedUpdate()
        {
            if(b_IsMove)
            {
                Move();
                Zoom();
            }
            else if(b_IsGameOver)
            {
                SetCameraToGameOverCondition();
            }

            // Reset damp time if its value is not equal to original damp time.
            if(dampTime != originalDampTime && !b_IsGameOver && b_IsMove)
            {
                ResetDampTime();
            }
        }

        private void GameOver()
        {
            b_IsGameOver = true;
            b_IsMove = false;
            RemoveAllCameraTargetPositions();
        }

        // To move camera to fixed position and fixed orthographic size after player death.
        private void SetCameraToGameOverCondition()
        {
            transform.position = Vector3.SmoothDamp(transform.position, gameOverCameraPostion, ref moveVelocity, 2f);
            camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, gameOverCameraOrthographicSize, ref zoomSpeed, 2f);
        }

        // To stop camera movement in paused state.
        private void GamePaused()
        {
            b_IsMove = false;
        }

        private void GameResumed()
        {
            b_IsMove = true;
        }

        // To move camera to desired position.
        private void Move()
        {
            FindAveragePosition();

            // To achieve smooth movement of camera.
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);
        }

        // Finds average position of all active tanks. i.e finds desired move position.
        private void FindAveragePosition()
        {
            Vector3 averagePos = new Vector3();
            int numTargets = 0;

            for(int i = 0; i < targets.Count; i++)
            {
                // If the target isn't active, go on to the next one.
                if (!targets[i].gameObject.activeSelf)
                {
                   continue;
                }

                // To shift camera more towards player or to ensure player dosen't go out of view.
                if(i == 0 && !b_IsGameOver)
                {
                    averagePos += targets[i].position * 3;
                    numTargets += 3;
                }
                else
                {
                    averagePos += targets[i].position;
                    numTargets++;
                }
            }

            if(numTargets > 0)
            {
                averagePos /= numTargets;
            }

            averagePos.y = transform.position.y;
            desiredPosition = averagePos;
        }

        // To set camera orthographic size.
        private void Zoom()
        {
            // Find the required size based on the desired position and smoothly transition to that size.
            float requiredSize = FindRequiredSize();
            camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, requiredSize, ref zoomSpeed, dampTime);
        }

        // x and y are local values of camera position.
        // orthographic size = distance in y axis 
        // orthographic size = distance in x axis / camera aspect 

        // We select the maximum value of size so that all tanks will be in camera view.
        private float FindRequiredSize()
        {
            // Find the position the camera rig is moving towards in its local space.
            Vector3 desiredLocalPosition = transform.InverseTransformPoint(desiredPosition);
            float size = 0f;

            for(int i = 0; i < targets.Count; i++)
            {
                if(!targets[i].gameObject.activeSelf)
                {
                    continue;
                }

                // Find the position of the target in the camera's local space.
                Vector3 targetLocalPosition = transform.InverseTransformPoint(targets[i].position);

                // Find the position of the target from the desired position of the camera's local space.
                Vector3 desiredPositionToTarget = targetLocalPosition - desiredLocalPosition;

                // Selecting max value of size.
                size = Math.Max(size, Mathf.Abs(desiredPositionToTarget.y));
                size = Mathf.Max(size, Mathf.Abs(desiredPositionToTarget.x) / camera.aspect);
            }

            size = Mathf.Min(size, MaxSize);

            // Add the edge buffer to the size.
            size += screenEdgeBuffer;

            size = Mathf.Max(size, MinSize);

            return size;
        }

        // To add newly created tanks trasform to target list.
        public void AddCameraTargetPosition(Transform target)
        {
            dampTime = targetAdditionDampTime;
            targets.Add(target);
        }

        // To remove specified transform from target list.
        public void RemoveCameraTargetPosition(Transform target)
        {
            if(!b_IsGameOver)
            {
                dampTime = targetAdditionDampTime;
            }
            targets.Remove(target);
        }

        // To remove all transforms from target list.
        public void RemoveAllCameraTargetPositions()
        {         
            for (int i = 0; i < targets.Count; i++)
            {
                targets.Remove(targets[i]);
            }
        }

        private void ResetDampTime()
        {
            dampTime = Mathf.Lerp(dampTime, originalDampTime, Time.deltaTime);
        }
    }
}
