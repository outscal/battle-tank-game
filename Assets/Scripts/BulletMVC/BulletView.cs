using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    WaitForSeconds timeToDisable = new WaitForSeconds(4f);
    public void SetBulletViewController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    private void Start()
    {
        if (bulletController != null)
            bulletController.UpdateBulletMovement();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (bulletController != null)
        {
            bulletController.DisableBullet(col);
            StartCoroutine(HoldBeforeDestroy());
        }

    }

    IEnumerator HoldBeforeDestroy()
    {
        yield return timeToDisable;
        bulletController.DestroyBullet();
    }

}
