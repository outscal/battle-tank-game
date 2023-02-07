using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;
    private Rigidbody rb;
    public ParticleSystem Explosion;
    private Vector3 spawnposition;
    public BulletController(BulletModel _bulletmodel, BulletView _bulletview, Transform SpawnTransform)
    {
        bulletModel = _bulletmodel;
        spawnposition = SpawnTransform.position;
        bulletView =  GameObject.Instantiate<BulletView>(_bulletview, SpawnTransform.position, SpawnTransform.rotation);
        rb = bulletView.GetComponent<Rigidbody>();
        Launch();
        this.bulletView.SetBulletController(this);
        this.bulletModel.SetBulletController(this);
    }
    private void Launch()
    {
        rb.velocity = rb.transform.forward * bulletModel.bulletSpeed;
    }
    public void Explode()
    {
        Explosion = bulletView.GetComponentInChildren<ParticleSystem>();
        Explosion.transform.SetParent(null);
        Explosion.Play(); 
    }
    public BulletModel GetBulletModel()
    {
        return bulletModel;
    }
    private float CalculateDamage(Vector3 targetPosition)
    { 
        Vector3 ExplosionToTarget = targetPosition - rb.transform.position;
        float explosionDistance = ExplosionToTarget.magnitude;
        float relativeDistance = (bulletModel.ExplosionRadius - explosionDistance)/bulletModel.ExplosionRadius;
        float damage = relativeDistance * bulletModel.bulletDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }
    public void bulletContact()
    {   Explode();
        Debug.Log("bulletcollided");
        Collider[] colliders = Physics.OverlapSphere(rb.transform.position, bulletModel.ExplosionRadius, bulletView.TankMask);
        for(int i = 0; i<colliders.Length; i++)
        {
            Rigidbody targetTank = colliders[i].GetComponent<Rigidbody>();
            if(!targetTank)
            {
                continue;
            }
            targetTank.AddExplosionForce(bulletModel.ExplosionForce, rb.transform.position, bulletModel.ExplosionRadius);
            float damage = CalculateDamage(targetTank.position);
            if(targetTank.GetComponent<TankView>() != null)
            {
                var tank = targetTank.GetComponent<TankView>();
                tank.GetDamage(damage);
            }
            else if(targetTank.GetComponent<EnemyView>() != null)
            {
                var tank = targetTank.GetComponent<EnemyView>();
                tank.GetDamage(damage);
            }
        }
    }
}
    
