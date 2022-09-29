using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    BulletController bulletController;
    public void SetBulletViewController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    private void Update()
    {
    }

}
