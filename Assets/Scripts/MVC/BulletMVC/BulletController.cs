using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private BulletView bulletView;
    private BulletModel bulletModel;


    public BulletController(BulletModel _BulletModel, BulletView _BulletView)
    {
        bulletModel = _BulletModel;
        bulletView = GameObject.Instantiate<BulletView>(_BulletView);
        GameObject gameObject = bulletView.GetParticalEffect();
        gameObject = GameObject.Instantiate(bulletModel.Partical);

        bulletView.SetBulletController(this);
        bulletModel.SetBulletController(this);
    }
    public void IsSetActive(bool isActive)
    {
        bulletView.ToggelActive(isActive);
    }
    public void ShootBullet(Transform bulletSpawnPoint)
    {
        bulletView.transform.SetPositionAndRotation(bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bulletView.GetRigidbody().AddForce(bulletView.transform.forward * bulletModel.Speed * Time.deltaTime, ForceMode.Force);
    }
    public void ReturnToPool(GameObject Obj)
    {
       // BulletObjecctPool.Instance.ReturnToPool(Obj);
    }
}
