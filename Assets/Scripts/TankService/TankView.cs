using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TankView : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public Quaternion GetTfRotation()
    {
        return transform.rotation;
    }


    // to transfer completely to tankController will have to either not use current transform.rotation
    // else pass transform.rotation vector3 current value to tank controller as well.
    //public void MoveFunction(Vector3 moveDirection, int speed, float degs)
    //{
    //    Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
    //    targetRotation = Quaternion.RotateTowards
    //    (
    //    transform.rotation,
    //    targetRotation,
    //        degs * Time.fixedDeltaTime
    //    );

    //    rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
    //    rb.MoveRotation(targetRotation);
    //}
}
