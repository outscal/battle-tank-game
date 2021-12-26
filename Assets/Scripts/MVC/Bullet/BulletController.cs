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
        Collider[] colliders = Physics.OverlapSphere(BulletView.transform.position, BulletModel.ExplosionRadius, BulletView.LayerMask);

        for(int i=0; i < colliders.Length; i++)
        {     
            IDamagable damagable = other.GetComponent<IDamagable>();

            if(damagable != null)
            {
                ApplyDamage(damagable, other);
                ApplyExplosionForce(other);
            }
        }

        PlayParticleEffects();
        PlayExplosionSound();

        BulletView.DestroyBullet();
    }


    private void ApplyDamage(IDamagable damagable, Collider other)
    {
        Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();

        if (targetRigidbody)
        {
            float damage = CalculateDamage(targetRigidbody.position);
            damagable.TakeDamage((int)damage);
        }
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - BulletView.transform.position;

        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (BulletModel.ExplosionRadius - explosionDistance) / BulletModel.ExplosionRadius;

        float damage = relativeDistance * BulletModel.BulletDamage;
        damage = Mathf.Max(0, damage);

        return damage;
    }


    private void ApplyExplosionForce(Collider other)
    {
        Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();

        if (targetRigidbody)
        {
            targetRigidbody.AddExplosionForce(BulletModel.ExplosionForce, BulletView.transform.position, BulletModel.ExplosionRadius);
        }
    }


    private void PlayParticleEffects()
    {
        ParticleSystem explosionParticles = BulletView.ExplosionParticles;
        explosionParticles.transform.parent = null;
        explosionParticles.Play();
        BulletView.DestroyParticleSystem(explosionParticles);
    }


    private void PlayExplosionSound()
    {
        BulletView.ExplosionSound.Play();
    }

}
