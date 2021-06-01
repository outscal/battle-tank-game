using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] [Range(0, 30)] private float m_speed = 3f;
    private float m_horizontal;
    private float m_vertical;

    private void Update()
    {
        PlayerMove(m_horizontal);
    }
    private void PlayerMove(float m_horizontal)
    {
        m_horizontal = joystick.Horizontal;
        m_vertical = joystick.Vertical;
        Vector2 convertedXY = ConvertWithCamera(Camera.main.transform.position, m_horizontal, m_vertical);
        Vector3 direction = new Vector3(convertedXY.x, 0, convertedXY.y).normalized;
        transform.Translate(direction * m_speed, Space.World);
    }

    private Vector2 ConvertWithCamera(Vector3 cameraPos, float hor, float ver)
    {
        Vector2 joyDirection = new Vector2(hor, ver).normalized;
        Vector2 camera2DPos = new Vector2(cameraPos.x, cameraPos.z);
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 cameraToPlayerDirection = (Vector2.zero - camera2DPos).normalized;
        float angle = Vector2.SignedAngle(cameraToPlayerDirection, new Vector2(0, 1));
        Vector2 finalDirection = RotateVector(joyDirection, -angle);
        return finalDirection;
    }

    public Vector2 RotateVector(Vector2 v, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float _x = v.x * Mathf.Cos(radian) - v.y * Mathf.Sin(radian);
        float _y = v.x * Mathf.Sin(radian) + v.y * Mathf.Cos(radian);
        return new Vector2(_x, _y);
    }
}