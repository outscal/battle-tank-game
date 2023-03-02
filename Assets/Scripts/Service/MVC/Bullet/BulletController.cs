using UnityEngine;
public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;
    private Rigidbody rb;
    private Vector3 spawnposition;
    private TypeDamagable shooterType;
    public BulletController(BulletModel _bulletmodel, BulletView _bulletview, Transform SpawnTransform)
    {
        bulletModel = _bulletmodel;
        spawnposition = SpawnTransform.position;
        bulletView =  GameObject.Instantiate<BulletView>(_bulletview, SpawnTransform.position, SpawnTransform.rotation);
        rb = bulletView.GetComponent<Rigidbody>();
        this.bulletView.SetBulletController(this);
        this.bulletModel.SetBulletController(this);
    }
    private void Launch()
    {
        rb.velocity = rb.transform.forward * bulletModel.BulletSpeed;
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
        float damage = relativeDistance * bulletModel.Damage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }
    public void bulletContact()
    {
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
            if(targetTank.GetComponent<EnemyView>() != null)
            {
                var _Object = targetTank.GetComponent<EnemyView>();
                _Object.GetDamage(damage,shooterType);
            }
             else if(targetTank.GetComponent<TankView>() != null)
            {
                var tank = targetTank.GetComponent<TankView>();
                tank.GetDamage(damage,shooterType);
            }
            bulletView.DestroyBullet();
        }
    }
    public void ActivateObject(Transform spawn, TypeDamagable type)
    {
        shooterType = type;
        this.bulletView.gameObject.SetActive(true);
        bulletView.transform.position = spawn.position;
        bulletView.transform.rotation = spawn.rotation;
        bulletView.GetComponent<MeshRenderer>().enabled = true;
        Launch();
    }
}
    
