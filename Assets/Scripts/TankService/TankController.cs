using UnityEngine;

public class TankController
{
    public TankModel tankModel { get; }
    public TankView tankView { get; }

    private Rigidbody rb;

    public TankController(TankModel _tankModel, TankView tankPrefab)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(tankPrefab);
    }

    public void Move(Vector2 _moveDirection)
    {
        //Vector3 moveDirection = new Vector3(_moveDirection.x, 0, _moveDirection.y);

        Vector3 moveDirection = _moveDirection.vector2ToVector3();
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        targetRotation = Quaternion.RotateTowards
        (
        tankView.GetRotation(),
        targetRotation,
            tankModel.RotateSpeed * Time.fixedDeltaTime
        );

        if(rb == null)
        {
            rb = tankView.GetRigidbody();
        }
        
        // this can be in tankView will eliminate need to store rigidbody here
        rb.MovePosition(rb.position + moveDirection * tankModel.Speed * Time.deltaTime);
        rb.MoveRotation(targetRotation);
    }

    public void Jump()
    {
        if(!rb)
        {
            rb = tankView.GetRigidbody();
        }
        rb.AddForce(Vector3.up * tankModel.JumpForce, ForceMode.Impulse);
    }
};
