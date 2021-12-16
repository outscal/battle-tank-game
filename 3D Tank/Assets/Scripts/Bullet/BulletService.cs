using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //Summary//
    //Script Responsible for processing the bullet data
    //-Summary/
public class BulletService : MonoBehaviour
{
    public BulletView bulletView;
    public BulletStats[] stats;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))           //getting the input from mouse button
        {                                          
            InitiateBullet();
        }
    }

    private BulletController InitiateBullet()     //processing the data for bullet prefab
    {
        BulletStats Stats = stats[2];
        BulletModel model = new BulletModel(Stats);
        BulletController bullet = new BulletController(model, bulletView);
        return bullet;
    }
}
