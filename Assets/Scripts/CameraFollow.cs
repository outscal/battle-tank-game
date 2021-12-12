using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private float smoothSpeed = 0.005f;
    private Transform target;
    [SerializeField]  private Vector3 offset;
    private Vector3 desiredposition;
    private Vector3 smoothPosition;
    private Transform playerLastPos;
    public static CameraFollow instance;

    void Awake()
    {
        instance = this;
    }

    public void SetTarget(Transform target)
    {
        if (target != null)
        {
            this.target = target;
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            offset = new Vector3(-300f, 300f, -300f);
            desiredposition = target.position + offset;
            playerLastPos = target;
        }
        else
        {
            cam.orthographicSize = 25f;
            target = playerLastPos;
        }

        smoothPosition = Vector3.Lerp(this.transform.position, desiredposition, smoothSpeed);
        transform.position = smoothPosition;
        transform.LookAt(target);
    }
}
