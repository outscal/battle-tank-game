using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{
    public BulletController(BulletModel bulletModel, BulletView bulletPrefab,Transform spawner)
    {
        BulletModel = bulletModel;
        Vector3 newPos = spawner.transform.position;
    
     
        BulletPrefab = GameObject.Instantiate(bulletPrefab, spawner.transform.position, spawner.transform.rotation);
        Rigidbody rb = BulletPrefab.GetComponent<Rigidbody>();
        //rb.AddForce(new Vector3(0,0, newPos.z)*bulletModel.Speed*100);
        rb.velocity = spawner.transform.forward* BulletModel.Speed;
        bulletPrefab.SetBulletDetails(BulletModel);

    }

    public BulletModel BulletModel { get; }
    public BulletView BulletPrefab { get; }
}
