using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float cam_DampTime = 0.2f;
    public float cam_ScreenEdgeBuffer = 4f;
    public float cam_MinSize = 6.5f;
    /* [HideInInspector] */ public List<Transform> cam_Targets = new List<Transform>();

    private Camera cam_Camera;
    private float cam_ZoomSpeed;
    private Vector3 cam_MoveVelocity;
    private Vector3 cam_DesiredPosition;

    private void Awake()
    {
        cam_Camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        cam_Targets.Clear();
        if (AssetManager.Instance.TankView && !cam_Targets.Contains(AssetManager.Instance.TankView.transform))
            cam_Targets.Add(AssetManager.Instance.TankView.transform);

        List<EnemyView> enemyViews = AssetManager.Instance.EnemyViews;
        int enemiesCount = enemyViews.Count;
        for (int i = 0; i < enemiesCount; i++)
        {
            EnemyView enemyView = enemyViews[i];
            if(enemyView != null && !cam_Targets.Contains(enemyView.transform))
                cam_Targets.Add(enemyView.transform);
        }

        Move();
        Zoom();
    }

    private void Move()
    {
        FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, cam_DesiredPosition, ref cam_MoveVelocity, cam_DampTime);
    }

    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        int camTargetsCount = cam_Targets.Count;
        for (int i = 0; i < camTargetsCount; i++)
        {
            Transform camTarget = cam_Targets[i];
            if (!camTarget || !camTarget.gameObject.activeSelf)
                continue;

            averagePos += cam_Targets[i].position;
            numTargets++;
        }

        if(numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;

        cam_DesiredPosition = averagePos;
    }

    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        cam_Camera.orthographicSize = Mathf.SmoothDamp(cam_Camera.orthographicSize, requiredSize, ref cam_ZoomSpeed, cam_DampTime);
    }

    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(cam_DesiredPosition);

        float size = 0f;

        int camTargetsCount = cam_Targets.Count;
        for (int i = 0;i < camTargetsCount;i++)
        {
            Transform camTarget = cam_Targets[i];
            if (!camTarget || !camTarget.gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(cam_Targets[i].position);

            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max(size,Mathf.Abs (desiredPosToTarget.y));

            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / cam_Camera.aspect);
        }

        size += cam_ScreenEdgeBuffer;

        size = Mathf.Max(size, cam_MinSize);

        return size;
    }

    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        transform.position = cam_DesiredPosition;

        cam_Camera.orthographicSize = FindRequiredSize();
    }
}
