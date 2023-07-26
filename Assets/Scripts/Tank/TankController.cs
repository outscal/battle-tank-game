
using Unity.VisualScripting;
using UnityEngine;

public class TankController
{
    public TankController(TankModel tankModel, TankView prefabTankView)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(prefabTankView);
        TankModel.getTankController(this);
        TankView.getTankController(this);
        TankService.Instance.playerTankFollower.AddFollower(TankView);
    }
    
    public TankModel TankModel { get; }
    public TankView TankView { get; }

    public void Move(Direction direction)
    {
        TankView.gameObject.GetComponent<Rigidbody>().MovePosition(TankView.gameObject.transform.position + TankView.gameObject.transform.forward * (int)direction  * TankModel.Speed * Time.deltaTime)  ;
    }

    public void MoveTransform(Direction direction)
    {
        TankView.gameObject.transform.position += TankView.gameObject.transform.forward * (int)direction * TankModel.Speed * Time.deltaTime;
    }

    public void RotateToDirection(Vector2 direction)
    {
        Vector3 towards = new Vector3(direction.x,0,direction.y);
        Quaternion lookRotation = Quaternion.LookRotation(towards);
        TankView.gameObject.transform.rotation = Quaternion.Slerp(TankView.gameObject.transform.rotation, lookRotation, 0.1f*direction.magnitude);
    }


}

public enum Direction { front = 1 , back = -1};
