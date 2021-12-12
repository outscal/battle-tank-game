using UnityEngine;

public class BulletController 
{
    public BulletModel BulletModel { get; }
    public BulletView BulletView { get; }

    public BulletController(BulletModel model, BulletView bulletPrefab)
    {
        BulletModel = model;
        BulletView = GameObject.Instantiate<BulletView>(bulletPrefab);
        BulletView.SetBulletController(this);
    }

    public void FixedUpdateBulletController()
    {

    }

    public void OnCollisionEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();

        if(damagable == null)
        {
            damagable.TakeDamage(BulletModel.BulletDamage);

            Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();

            if (targetRigidbody)
            {
                targetRigidbody.AddExplosionForce(1000, BulletView.transform.position, 5);
            }
        }
    }

}
