using UnityEngine;

public class TankView : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void MoveFunction(Vector3 moveDirection, int speed, float degs)
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        targetRotation = Quaternion.RotateTowards
        (
        transform.rotation,
        targetRotation,
            degs * Time.fixedDeltaTime
        );

        rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
        rb.MoveRotation(targetRotation);
    }

    public void JumpFunction(float jumpSpeed)
    {
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }
}
