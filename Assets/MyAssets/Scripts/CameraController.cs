using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.005f;
    [SerializeField] private Vector3 offset;


    private void LateUpdate()
    {
        Vector3 desiredposition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredposition, smoothSpeed);
        transform.position = smoothPosition;

        transform.LookAt(target);
    }
}
