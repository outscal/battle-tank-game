using UnityEngine;
public class BulletModel
{
    //bullet properties
    public BulletTypes BulletType;
    public string BulletName;
    public float Speed { get; }
    BulletController _bulletController;

    //constructor
    public BulletModel(BulletSO bulletScriptableObject)
    {
        BulletType = bulletScriptableObject.BulletType;
        BulletName = bulletScriptableObject.BulletName;
        Speed = bulletScriptableObject.Speed;
    }


    public void SetController(BulletController bulletController)
    {
        _bulletController = bulletController;
    }

}