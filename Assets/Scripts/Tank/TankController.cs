using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TankController
{
    public TankModel tankModel { get; }
    public TankView tankView { get; }
    public TankController(TankModel _tankModel, TankView _prefabTankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_prefabTankView,getRandPosInWorld(),Quaternion.identity);
        tankModel.getTankController(this);
        tankView.getTankController(this);
    }

    private Vector3 getRandPosInWorld()
    {
        return new Vector3(Random.Range(0, 30), 1f, Random.Range(0, 30));
    }

    public virtual void UpdateAutoControls()
    {

    }
    public virtual void UpdateCollisionControls()
    {

    }
    public virtual void onBulletHit()
    {
        tankModel.health -= 20;
        if (tankModel.health < 0)
        {
            GameObject.Destroy(tankView.gameObject);
        }
    }
}


public enum Direction { front = 1 , back = -1};
