using UnityEngine;

public class BulletController
{
    public BulletController(BulletScriptableObject _bullet, Transform _transform, Rigidbody _rb)
    {
        bulletView = GameObject.Instantiate<BulletView>(_bullet.bulletView, _transform.position, _transform.rotation);
        bulletModel = new BulletModel(_bullet);

        bulletView.SetBulletController(this);
        bulletModel.SetBulletController(this);

        rb = bulletView.GetRigidbody();
        tankRB = _rb;
    }
    private BulletModel bulletModel;
    private BulletView bulletView;
    Rigidbody rb;
    Rigidbody tankRB;
    public void Shoot()
    {
        rb.AddForce(rb.transform.forward * bulletModel.range, ForceMode.Impulse);
    }
}
