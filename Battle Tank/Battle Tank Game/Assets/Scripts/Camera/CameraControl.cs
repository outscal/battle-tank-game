using System;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float DampTime = 0.2f;
    public float ScreenEdgeBuffer = 4f;
    public float MinSize = 6.5f;
    /*[HideInInspector]*/ public Transform[] Targets;

    private Camera m_camera;
    private float ZoomSpeed;
    private Vector3 moveVelocity;
    private Vector3 DesiredPosition;

    private void Awake()
    {
        m_camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        Move();
        Zoom();
    }


    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, DesiredPosition, ref moveVelocity, DampTime);
    }

    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for(int i = 0; i < Targets.Length; i++)
        {
            if(!Targets[i].gameObject.activeSelf)
            {
                continue;
            }
            averagePos += Targets[i].position;
            numTargets++;
        }

        if(numTargets > 0)
            averagePos /= numTargets;
        averagePos.y = transform.position.y;
        DesiredPosition = averagePos;
    }

    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        m_camera.orthographicSize = Mathf.SmoothDamp(m_camera.orthographicSize, requiredSize, ref ZoomSpeed, DampTime);
    }

    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(DesiredPosition);

        float size = 0f;

        for(int i = 0; i < Targets.Length; i++)
        {
            if(!Targets[i].gameObject.activeSelf)
                continue;
            Vector3 targetLocalPos = transform.InverseTransformPoint(Targets[i].position);
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / m_camera.aspect);
        }

        size += ScreenEdgeBuffer;
        size = Mathf.Max(size, MinSize);
        return size;
    }

    public void SetStartPositionAndSize()
    {
        FindAveragePosition();
        transform.position = DesiredPosition;
        m_camera.orthographicSize = FindRequiredSize();
    }
}
