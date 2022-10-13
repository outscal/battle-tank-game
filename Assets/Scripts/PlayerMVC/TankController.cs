using UnityEngine;


public class TankController
{
    private TankView tankView;
    private TankModel tankModel;
    Vector3 moveVector = Vector3.zero;
    bool isDisabled = false;

    public TankController(TankView _tankView, TankModel _tankModel, int spawnIndex)
    {
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankModel = _tankModel;
        tankView.SetTankController(this);
        tankModel.SetTankController(this);
    }

    public void UpdateMovementAndRotation(float horizontalInput, float verticalInput)
    {
        if (isDisabled)
            return;
        tankView.gameObject.transform.position += Time.deltaTime * tankView.gameObject.transform.forward * tankModel.MovSpeed;
        moveVector.x = horizontalInput;
        moveVector.z = verticalInput;
        tankView.gameObject.transform.forward = moveVector;
    }

    public void Shoot()
    {
        if (isDisabled)
            return;
        tankView.bulletService.InstantiateBullet(tankModel.SpawnIndex);
    }

    public void DisableTank()
    {
        isDisabled = true;
    }

    public void DestroyTank()
    {
        GameObject.Destroy(tankView.gameObject);
    }

}
