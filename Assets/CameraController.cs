using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float smoothSpeed = 0.125f; // The smoothness factor for camera movement
    public Vector3 offset; // The offset from the target position

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}
