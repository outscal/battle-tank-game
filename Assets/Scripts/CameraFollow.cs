using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform tank;
    private float speed = 0.125f;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (tank != null)
        {
            Vector3 desiredPosition = tank.position + offset;
            Vector3 smoothPos = Vector3.Lerp(tank.position, desiredPosition, speed);
            transform.position = smoothPos;

            transform.LookAt(tank);
        }

    }
}
