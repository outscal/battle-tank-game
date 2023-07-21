using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{
    private BulletView bulletView;
    private BulletModel bulletModel;
    private ParticleSystem Sellexposions;
    private Rigidbody rb;
    public BulletController(BulletModel _BulletModel, BulletView _BulletView, Transform GunSpawn)
    {
        bulletModel = _BulletModel;
        bulletView = GameObject.Instantiate<BulletView>(_BulletView,GunSpawn.position, GunSpawn.rotation);
        GameObject gameObject = bulletView.GetParticalEffect();
        gameObject = GameObject.Instantiate(bulletModel.Partical);
        bulletView.SetBulletController(this);
        bulletModel.SetBulletController(this);
        rb = bulletView.GetRigidbody();
    }
    public void IsSetActive(bool isActive)
    {
        bulletView.ToggelActive(isActive);
    }
    public void ShootBullet(Transform bulletSpawnPoint)
    {
        rb.transform.position = bulletSpawnPoint.position;
        rb.transform.rotation = bulletSpawnPoint.rotation;
        rb.AddForce(rb.transform.forward * bulletModel.Speed, ForceMode.Force);
    }
    public void ReturnBulletToPool()
    {
        bulletView.GetComponent<MeshRenderer>().enabled = true;
        IsSetActive(false);     
        BulletService.Instance.poolService.ReturnItem(this);
        bulletView.GetParticalEffect().SetActive(false);
        Sellexposions.Stop(true);
    }
}
