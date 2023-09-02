using System;
using UnityEngine;

public class BulletServices : MonoBehaviour
{
    public BulletScriptableObjectList BulletList;
    public BulletController BulletController;
    public BulletView bulletPrefab;
    public BulletModel bulletModel;
    public BulletScriptableObject bulletObject;
    public TankService PlayerService;
    void Awake()
    {
        Bullet();
    }
    private void Bullet()
    {
        int bulletIndex = UnityEngine.Random.Range(0, BulletList.bulletObjects.Length);
        this.bulletObject = BulletList.bulletObjects[bulletIndex];
        bulletModel = new BulletModel(bulletObject);
        BulletController = new BulletController(bulletModel, bulletObject);
        bulletPrefab = bulletObject.bulletView;
        bulletPrefab.SetBulletController(BulletController,bulletModel);
    }

    public void Shoot(Transform shootPoint,GameObject shooter)
    {
        //Transform shootPoint = PlayerService.PlayerController.PlayerView.GetshootPoint();
        //Bullet();
        
        BulletView bullet = GameObject.Instantiate<BulletView>(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.SetShooterObject(shooter);
    }
}
