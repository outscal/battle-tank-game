using UnityEngine;

public class TankBulletModel
{
    public TankBulletModel(TankBulletScriptableObject tankBulletScriptableObject)
    {
        TankBUlletType = tankBulletScriptableObject.TankBUlletType;
        BulletPrefab = tankBulletScriptableObject.BulletPrefab;
        BulletSpeed = tankBulletScriptableObject.BulletSpeed;
        BulletDamage = tankBulletScriptableObject.BUlletDamage;
    }

 

    public TankBUlletType TankBUlletType { get; }

    public Transform BulletSpawnPosition { get; }
    public GameObject BulletPrefab { get; }
    public float BulletSpeed { get; }

    public int BulletDamage { get; }
}
