using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    float horizontalMove;
    float verticalMove;
    Vector3 direction;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void PlayerInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal1");
        verticalMove = Input.GetAxisRaw("Vertical1");
        direction = Vector3.forward * verticalMove + Vector3.right * horizontalMove;
        direction = Quaternion.Euler(0, 60, 0) * direction;
    }
    void PlayerMove()
    {
        rb.velocity = direction.normalized * speed;
        transform.LookAt(direction + transform.position);
    }
    void Update()
    {
        PlayerInput();
        PlayerMove();
    }
}
