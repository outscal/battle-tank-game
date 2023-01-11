using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The tank object
    public float followSpeed = 10f;
    public Vector3 offset;
    private Quaternion rotation; // Store the camera's current rotation

    void Start()
    {
        rotation = transform.rotation;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = transform.position.y;  // Keep the camera's y position fixed
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, followSpeed * Time.deltaTime);
    }
}
