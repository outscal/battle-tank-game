using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform tank;
    [SerializeField] private float smoothTime = 0.25f;
    [SerializeField] private Vector3 offset;
    private Vector3 velocity;


    private void LateUpdate()
    {
        // Calculate the target position based on the target's position plus the offset
        Vector3 targetPosition = tank.position + offset;

        // Smoothly move the camera towards the target position using SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
