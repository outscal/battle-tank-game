using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void FixedUpdate()
    {
        Vector3 DesiredPosition = target.position + offset;
        //Vector3 smoothPosition = Vector3.Slerp(transform.position, DesiredPosition,smoothSpeed);
        //transform.position = smoothPosition;
        //transform.position = DesiredPosition;
        transform.LookAt(target.position);
    }
}
