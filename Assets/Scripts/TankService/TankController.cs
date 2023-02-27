using UnityEngine;

public class TankController
{
    public TankModel tankModel { get; }
    public TankView tankView { get; }

    public TankController(TankModel _tankModel, TankView tankPrefab)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(tankPrefab);
        // tankView = Object.Instantiate(_tankView);

    }

    public void Move(Vector2 _moveDirection)
    {
            Vector3 moveDirection = new Vector3(_moveDirection.x, 0, _moveDirection.y);

            tankView.MoveFunction(moveDirection, tankModel.Speed, tankModel.RotateSpeed);
    }

    public void Jump()
    {
        tankView.JumpFunction(tankModel.JumpForce);
    }
};
