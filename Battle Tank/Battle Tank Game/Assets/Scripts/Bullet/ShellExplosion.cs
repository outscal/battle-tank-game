using System;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    private TankView player;
    public LayerMask TankMask;
    public ParticleSystem explosionParticles;
    public AudioSource explosionAudio;
    public float explosionForce = 500f;
    public float maxLifeTime = 2f;
    public float explosionRadius = 5f;
    
    void Start()
    {
        player = GameObject.FindObjectOfType<TankView>();
        Destroy(gameObject, maxLifeTime);
    }

    [Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, TankMask); 

        for(int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if(!targetRigidbody)
                continue;
            
            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);


            // reduce tank health using takedamage function of tank
            EnemyTankView targetHealth = targetRigidbody.GetComponent<EnemyTankView>();
                if(!targetHealth)
                    continue;
            float maxDamage = player.GetTankController().GetTankModel().tankDamage;
            float damage = CalculateDamage(targetRigidbody.position, maxDamage);
            
            targetHealth.GetEnemyTankController().TakeDamage(damage);
        }

        explosionParticles.transform.parent = null;

        explosionParticles.Play();
        explosionAudio.Play();

        Destroy(explosionParticles.gameObject, explosionParticles.duration);
        Destroy(gameObject);
    }

    private float CalculateDamage(Vector3 targetPosition, float maxDamage)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;
       
        float damage = relativeDistance * maxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }
}
