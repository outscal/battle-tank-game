using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    float horizontalMove;
    float verticalMove;
    Vector3 direction;
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void PlayerInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal1");
        verticalMove = Input.GetAxisRaw("Vertical1");
    }
    void Update()
    {
        PlayerInput();
        PlayerMove();
    }
    void PlayerMove()
    {
        direction = Vector3.right * horizontalMove + Vector3.forward * verticalMove;
    }
}
