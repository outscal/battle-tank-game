using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The target object to follow
    public Vector3 offset; // The offset from the target object
    public float smoothSpeed = 0.125f; // The speed at which the camera follows the target

    void LateUpdate()
    {
        // Move the camera position to the target position with the given offset and smoothness
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Rotate the camera to look at the target
        transform.LookAt(target);
    }
}