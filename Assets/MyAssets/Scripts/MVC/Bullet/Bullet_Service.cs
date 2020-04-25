using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Service : MonoSingletonGeneric<Bullet_Service>
{
    public BulletView bulletView;

    void Start()
    {
        BulletModel b_Model = new BulletModel(10);
        BulletController b_Controller = new BulletController(b_Model, bulletView);
    }
}
