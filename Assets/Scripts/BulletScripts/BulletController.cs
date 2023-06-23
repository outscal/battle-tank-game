using UnityEngine;

public class BulletController
{
    public BulletController(BulletScriptableObject _bullet, Vector3 _position)
    {
        bulletView = GameObject.Instantiate<BulletView>(_bullet.bulletView, _position + new Vector3(0, 1.55f, 0), Quaternion.identity);
        bulletModel = new BulletModel(_bullet);

        bulletView.SetBulletController(this);
        bulletModel.SetBulletController(this);

        rb = bulletView.GetRigidbody();
    }
    private BulletModel bulletModel;
    private BulletView bulletView;
    Rigidbody rb;
    public void Shoot()
    {
        rb.AddForce(rb.transform.forward * bulletModel.range, ForceMode.Impulse);
    }
}
