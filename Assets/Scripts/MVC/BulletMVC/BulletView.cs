using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private Rigidbody bulletrb;
    private BulletController bulletController1;
    private  GameObject particalEffect;
    public Rigidbody GetRigidbody() => bulletrb;
    public GameObject GetParticalEffect() => particalEffect;

    public  void SetBulletController(BulletController bulletController)
    {
        bulletController1 = bulletController;
    }

    internal void ToggelActive(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }
   
}
