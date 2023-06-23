using UnityEngine;

public class BulletController
{
    public BulletController(BulletScriptableObject _bullet, Transform _transform)
    {
        bulletView = GameObject.Instantiate<BulletView>(_bullet.bulletView, _transform.position, _transform.rotation);
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
    public void BulletCollision(Vector3 position)
    {
        BulletService.Instance.BulletExplosion(position, bulletView);
    }
    public int GetBulletDamage()
    {
        return bulletModel.damage;
    }
}
