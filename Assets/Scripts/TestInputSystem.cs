using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystem : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    public float speed = 8f;
    public float degs = 360f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.jump.performed += Jump;

    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y).normalized;
        Debug.Log(moveDirection);

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            targetRotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                degs * Time.fixedDeltaTime);

            rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
            rb.MoveRotation(targetRotation);
        }
    }

 

    //using unity events
    public void Jump(InputAction.CallbackContext context)
    {

        Debug.Log(context);
        if(context.performed)
        {
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

    //public void Jump(InputAction.CallbackContext context)
    //{
    //    Debug.Log(context);
    //}
}
