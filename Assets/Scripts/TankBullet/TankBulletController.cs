using UnityEngine;

public class TankBulletController 
{
    private TankBulletModel tankBulletModel;
    private TankBulletView tankBulletView;
    public TankBUlletType tankBulletType;
    private GameObject bullet;
   

    public TankBulletController(TankBulletModel _tankBulletModel, TankBulletView _tankBulletView)
    {
        tankBulletModel = _tankBulletModel;
    
        tankBulletView = GameObject.Instantiate<TankBulletView>(_tankBulletView);
        tankBulletView.SetTankBulletController(this);
    }

    public void ShootBullet(Transform spawnPos)
    {
        tankBulletView.transform.SetPositionAndRotation(spawnPos.position,spawnPos.rotation);
        tankBulletView.GetComponent<Rigidbody>().velocity = spawnPos.forward * tankBulletModel.BulletSpeed;
    }

    public int BulletDamage()
    {
        return tankBulletModel.BulletDamage;
    }

    public void SetVisibilityStatus(bool isVisible)
    {
        tankBulletView.SetVisibilityStatus(isVisible);
    }
}
