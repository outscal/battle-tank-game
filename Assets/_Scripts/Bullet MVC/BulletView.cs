using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    BulletController bulletController;
    private void Awake()
    {
        Debug.Log("Bullet View created");
    }

    private void Update()
    {
        FireBullet(transform.eulerAngles);
    }

    public void FireBullet(Vector3 tankRotation)
    {
        transform.eulerAngles = tankRotation;

        //Vector3 position = transform.position; // *** this violates the MVC design pattern . need to find a better way. have to move the logic of firing the bullet inside the bullet controller script.
        //position.x += bulletController.BulletModel.Speed * Time.deltaTime;
        //transform.position = position;

        transform.Translate(Vector3.forward * bulletController.BulletModel.Speed * Time.deltaTime);
    }

    public void SetBulletController(BulletController bc)
    {
        bulletController = bc;
    }
}
