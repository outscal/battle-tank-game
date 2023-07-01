
using UnityEngine;

public class BulletController 
{
    private BulletView bulletView;
    public BulletController(BulletView bulletView)
    {
        this.bulletView = bulletView;
    }

    public void SetInitialVelocity()
    {
        bulletView.rb.velocity = bulletView.speed * bulletView.tankView.transform.forward;
    }
    public void MoveForword()
    {
        bulletView.rb.velocity = bulletView.speed * Time.deltaTime * bulletView.transform.forward;

    }
}
