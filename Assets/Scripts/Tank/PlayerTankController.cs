using UnityEngine;

public class PlayerTankController: TankController
{

    public PlayerTankController(TankModel _tankModel, TankView _prefabTankView) : base(_tankModel,  _prefabTankView)
    {
        TankService.Instance.playerTankFollower.AddFollower(tankView);
    }

    public void Move(Direction direction)
    {
        tankView.gameObject.GetComponent<Rigidbody>().MovePosition(tankView.gameObject.transform.position + tankView.gameObject.transform.forward * (int)direction * tankModel.speed * Time.deltaTime);
    }

    public void moveWithVelocity(Direction direction)
    {
        tankView.tankRb.velocity = tankView.gameObject.transform.forward * (int)direction * tankModel.speed;
    }

    public void MoveTransform(Direction direction)
    {
        tankView.gameObject.transform.position += tankView.gameObject.transform.forward * (int)direction * tankModel.speed * Time.deltaTime;
    }

    public void RotateToDirection(Vector2 direction)
    {
        Vector3 towards = new Vector3(direction.x, 0, direction.y);
        Quaternion lookRotation = Quaternion.LookRotation(towards);
        tankView.gameObject.transform.rotation = Quaternion.Slerp(tankView.gameObject.transform.rotation, lookRotation, 0.1f * direction.magnitude);
    }

    public override void DestroyTank()
    {
        tankModel.died = true;
        tankView.startDestroyCoroutine(0f);
        TankService.Instance.destroyAllTanks();
    }


}
