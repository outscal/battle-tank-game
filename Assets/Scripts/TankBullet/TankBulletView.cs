using UnityEngine;

public class TankBulletView : MonoBehaviour
{
    public TankBUlletType tankBulletType;
    public TankBulletController tankBulletController;
   

    public int GetDamage()
    {
        return tankBulletController.BulletDamage();
    }
    public void SetTankBulletController(TankBulletController _tankBulletController)
    {
        tankBulletController = _tankBulletController;
    }
}
