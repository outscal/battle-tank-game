using System.ComponentModel.Design;
using UnityEngine;

public class PlayerTankController: TankController
{
    private int distanceChecker = 5;
    public PlayerTankController(TankModel _tankModel, TankView _prefabTankView) : base(_tankModel,  _prefabTankView)
    {
        TankService.Instance.playerTankFollower.AddFollower(tankView);
    }

    /*public void Move(Direction direction)
    {
        tankView.gameObject.GetComponent<Rigidbody>().MovePosition(tankView.gameObject.transform.position + tankView.gameObject.transform.forward * (int)direction * tankModel.speed * Time.deltaTime);
    }*/

    public void moveWithVelocity(Direction direction)
    {
        tankView.tankRb.velocity = tankView.gameObject.transform.forward * (int)direction * tankModel.speed;
    }

   /* public void MoveTransform(Direction direction)
    {
        tankView.gameObject.transform.position += tankView.gameObject.transform.forward * (int)direction * tankModel.speed * Time.deltaTime;
    }*/

    public void RotateToDirection(Vector2 direction)
    {
        Vector3 towards = new Vector3(direction.x, 0, direction.y);
        Quaternion lookRotation = Quaternion.LookRotation(towards);
        tankView.gameObject.transform.rotation = Quaternion.Slerp(tankView.gameObject.transform.rotation, lookRotation, 0.1f * direction.magnitude);
    }

    public override void DestroyTank()
    {
        TankService.Instance.playerTankController = null;
        tankModel.died = true;
        tankView.startDestroyCoroutine(0f);
        TankService.Instance.destroyAllTanks();
    }

    public override void UpdateTank()
    {
        if(!determineBlock())
        tankModel.distanceCovered += tankView.tankRb.velocity.magnitude * Time.deltaTime;
        tankView.checker = distanceChecker;
        messageAtDistanceMilestones();
    }


    private void messageAtDistanceMilestones()
    {
        if(tankModel.distanceCovered > distanceChecker)
        {
            TankService.Instance.checkDistanceAcheivement((int)tankModel.distanceCovered);
            distanceChecker += 5;
        }
    }

    private bool determineBlock()
    {
        Ray ray = new Ray(tankModel.shootertransform.position, tankView.transform.forward);
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo, 1f);
        if (hitInfo.collider!=null)
        {
            return true;
        }
        return false;
    }

}
