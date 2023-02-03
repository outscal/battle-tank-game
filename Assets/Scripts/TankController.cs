using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;
    private Rigidbody rb;
    
    public TankController(TankModel tankmodel, TankView tankview)
    {
        this.tankModel = tankmodel;
        tankView = GameObject.Instantiate<TankView>(tankview);
        rb = tankView.GetRigidbody();
        this.tankView.SetTankController(this);
        this.tankModel.SetTankController(this);
    }


   

    public void Move(float movementDirection, float moveSpeed)
    {
        var moveForward = tankView.transform.forward * movementDirection * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveForward);
    }
    public void Turn(float rotation, float TurnSpeed)
    {
        float turn = rotation * TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    public TankModel GetTankModel()
    {
        return tankModel;
    }
}
