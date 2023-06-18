using UnityEngine;
public class TankController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    float horizontalMove;
    float verticalMove;
    Vector3 direction;
    Rigidbody rb;
    Quaternion toRotation;
    [SerializeField] Joystick joystick;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void PlayerInput()
    {
        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;

        direction = Vector3.forward * verticalMove + Vector3.right * horizontalMove;
        direction = Quaternion.Euler(0, 60, 0) * direction;
    }
    void PlayerMove()
    {
        rb.velocity = direction.normalized * speed;
        transform.LookAt(direction.normalized + transform.position);
    }
    void Update()
    {
        PlayerInput();
        PlayerMove();
    }
}
