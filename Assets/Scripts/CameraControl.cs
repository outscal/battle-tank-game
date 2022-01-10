using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This Script will be used to control the camera
//follow with the player movement and zoom in or out depending upon the number of enemies in the game

public class CameraControl : MonoBehaviour
{
    public float DampTime;
    public float ScreenEdgeBuffer;
    public float MinSize;
    /*[HideInInspector]*/ public Transform[] Targets;   // Array of targets 

    private Camera Camera;
    private float ZoomSpeed;
    private Vector3 MoveVelocity;
    private Vector3 DesiredPosition;
    private void Awake()
    {
        DampTime = 0.2f;
        ScreenEdgeBuffer = 4f;
        MinSize = 6.5f;
        Camera = GetComponentInChildren<Camera>();
    }
    private void FixedUpdate()
    {
        Zoom();
        Move();
    }
    private void Move()
    {
        FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, DesiredPosition, ref MoveVelocity, DampTime);
    }
    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;
        for (int i = 0; i < Targets.Length; i++)
        {
            if (!Targets[i].gameObject.activeSelf)
                continue;    //If the above satisfies then continue to next iteration of loop
            averagePos += Targets[i].position;
            numTargets++;
        }
        if (numTargets > 0)
            averagePos /= numTargets;  //To claculate the positions between the no. of tanks 
        averagePos.y = transform.position.y;  // Make sure it doesnt go offgrid
        DesiredPosition = averagePos;
    }
    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        Camera.orthographicSize = Mathf.SmoothDamp(Camera.orthographicSize, requiredSize, ref ZoomSpeed, DampTime);
    }
    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(DesiredPosition);
        float size = 0f;
        for (int i = 0; i < Targets.Length; i++)
        {
            if (!Targets[i].gameObject.activeSelf)
                continue;
            Vector3 targetLocalPos = transform.InverseTransformPoint(Targets[i].position);
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / Camera.aspect);  // divide coz left to right comes aspect
        }
        size += ScreenEdgeBuffer;
        size = Mathf.Max(size, MinSize);
        return size;
    }      
        public void SetStartPositionAndSize()
        {
            FindAveragePosition();
            transform.position = DesiredPosition;
            Camera.orthographicSize = FindRequiredSize();
        }
}
