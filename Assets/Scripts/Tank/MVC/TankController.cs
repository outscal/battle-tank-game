using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private TankView tankView;
    private TankModel tankModel;
    Vector3 moveVector= Vector3.zero;
    
    public TankController(TankView _tankView, TankModel _tankModel)
    {
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankModel = _tankModel;
        tankView.SetTankController(this);
        tankModel.SetTankDController(this);
        
    }

    public void UpdateMovementAndRotation(float horizontalInput, float verticalInput)
    {
        tankView.gameObject.transform.position += Time.deltaTime * tankView.gameObject.transform.forward * tankModel.GetMoveSpeed();
        moveVector.x= horizontalInput;
        moveVector.z = verticalInput;
        tankView.gameObject.transform.forward = moveVector;
    }
}
