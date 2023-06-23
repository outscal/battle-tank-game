using UnityEngine;

public class BulletController
{
    public BulletController(BulletView bulletView, int _damage, int _speed, Vector3 position)
    {
        bulletView = GameObject.Instantiate<BulletView>(bulletView, position, Quaternion.identity);
        bulletModel = new BulletModel(_damage, _speed);

        bulletView.SetBulletController(this);
        bulletModel.SetBulletController(this);

        rb = bulletView.GetRigidbody();
    }
    private BulletModel bulletModel;
    private BulletView bulletView;
    Rigidbody rb;
    public void Shoot()
    {
        rb.AddForce(rb.transform.forward * bulletModel.speed, ForceMode.Impulse);
    }
}
