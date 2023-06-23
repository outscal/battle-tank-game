using UnityEngine;
public enum BulletType
{
    Sniper, Assault, Pistol
}
public class BulletService : GenericSingleton<BulletService>
{
    [SerializeField] BulletScriptableObjectList bulletList;
    public void Shoot(BulletType bulletType, Vector3 _position)
    {
        BulletController bulletController = new BulletController(bulletList.bullets[(int)bulletType], _position);
    }
}
