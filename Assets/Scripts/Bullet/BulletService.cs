
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService> 
{
    [SerializeField]
    private BulletView bulletPrefab;

    [SerializeField]
    private BulletScriptableObject bulletScriptableObject;
    public void GenerateBullet(PlayerTankView tankView,Vector3 pos)
    {
        BulletModel bulletModel = new(bulletScriptableObject);
        BulletController bulletController = new(bulletModel, bulletPrefab, pos, tankView.transform.rotation);
    }
}
