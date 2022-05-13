using System;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    public LayerMask tankMask;
    public ParticleSystem explosionParticles;
    public float maxDamage = 100f;
    public float explosionForce = 1000f;
    public float maxLifeTime = 2f;
    public float explosionRadius = 5f;


    private Transform bullet_sParent;

    private TankView PlayerTankBullet;
    private EnemyTankView EnemyTankBullet;

    public void Start()
    {
        //bullet_sParent = transform.parent.gameObject.transform.parent.gameObject.transform;
        //PlayerTankBullet = bullet_sParent.GetComponent<TankView>();
        //EnemyTankBullet = bullet_sParent.GetComponent<EnemyTankView>();
        Destroy(gameObject, maxLifeTime);
    }

    private void Update()
    {
        //    TankView go = bullet_sParent.gameObject.GetComponent<TankView>();

        //    if (bullet_sParent.gameObject.GetComponent<TankView>() == bullet_sParent.gameObject.GetComponent<TankView>())
        //    {
        //        Debug.Log("Bullet Founded Parent " + transform.parent.gameObject.transform.parent.gameObject.name);
        //        Debug.Log("Bullet Founded Parent " + bullet_sParent.gameObject.name);
        //    }

        //    Debug.Log("Bullet Not Found Parent " + bullet_sParent.gameObject.name);
    }

    [Obsolete]
    public void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].attachedRigidbody.GetComponent<Rigidbody>();

            //Debug.Log("targetRigidbody gameObject " + targetRigidbody.gameObject.name);

            //if (colliders[i].transform.parent == targetRigidbody.GetComponent<EnemyTankView>())
            //    Debug.Log("OnTriggerEnter Founded" + targetRigidbody.gameObject.name);


            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            //EnemyTankView targetHealth = targetRigidbody.GetComponent<EnemyTankView>();
            TankView targetHealth = targetRigidbody.GetComponent<TankView>();

            if (!targetHealth)
            {
                continue;
            }

            float damage = CalculateDamage(targetRigidbody.position);

            IDamagable damagable = targetRigidbody.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(damage);
                //damagable.TakeDamage(BulletModel.damage, BulletModel.Type);
            }
        }

        explosionParticles.transform.parent = null;
        explosionParticles.Play();
        Destroy(explosionParticles.gameObject, explosionParticles.duration);
        Destroy(gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;
        float damage = relativeDistance * maxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }
}


//Reference for Accessing Parent Game object
//TankView go = bullet_sParent.gameObject.GetComponent<TankView>();

//if (bullet_sParent.gameObject.GetComponent<TankView>() == bullet_sParent.gameObject.GetComponent<TankView>())
//{
//Debug.Log("Bullet Founded Parent " + transform.parent.gameObject.transform.parent.gameObject.name);
//Debug.Log("Bullet Founded Parent " + bullet_sParent.gameObject.name);
//}

//Debug.Log("Bullet Not Found Parent " + bullet_sParent.gameObject.name);