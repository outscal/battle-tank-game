using UnityEngine;

public class TankController {

    private TankModel tankModel;
    private TankView tankView;

    private Rigidbody rb;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);

        rb = tankView.GetRigiBody();
        
        tankView.SetTankController(this);
    }

    public void Move(float movement)
    {
        rb.velocity = tankView.transform.forward * movement * tankModel.GetMovementSpeed();
    }

    public void Rotate(float rotation)
    {
        Vector3 vector = new Vector3(0f, rotation * tankModel.GetRotationSpeed(), 0f);     // Rotating full TankBody
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
