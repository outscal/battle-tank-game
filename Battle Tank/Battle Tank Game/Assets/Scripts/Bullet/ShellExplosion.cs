using System;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    private TankView player;
    private EnemyTankView enemy;
    public LayerMask TankMask;
    public ParticleSystem explosionParticles;
    public AudioSource explosionAudio;
    public float explosionForce = 500f;
    public float maxLifeTime = 2f;
    public float explosionRadius = 5f;
    
    void Start()
    {
        player = GameObject.FindObjectOfType<TankView>(); 
        enemy = GameObject.FindObjectOfType<EnemyTankView>();       
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

            if( colliders[i].CompareTag("Player") )
            {   
                //player will get the damage from enemy tank
                Debug.Log("Player Taking Damage" + colliders[i]);
                TankView targetHealth = colliders[i].GetComponent<TankView>();

                if(!targetHealth)
                continue;
            
                float maxDamage = enemy.GetEnemyTankController().GetEnemyTankModel().tankDamage;                
                float damage = CalculateDamage(targetRigidbody.position, maxDamage);            
                targetHealth.GetTankController().TakeDamage(damage);            

            } 
            else if (colliders[i].CompareTag("Enemy"))
            {
                //enemy will get the damage from player tank
                Debug.Log("Enemy Taking Damage" + colliders[i]);
                EnemyTankView targetHealth = colliders[i].GetComponent<EnemyTankView>();

                if(!targetHealth)
                    continue;        
            
                float maxDamage = player.GetTankController().GetTankModel().tankDamage;
                float damage = CalculateDamage(targetRigidbody.position, maxDamage);                
                targetHealth.GetEnemyTankController().TakeDamage(damage);
            }     
             // reduce tank health using takedamage function of tank
            
            //     if(!targetHealth)
            //         continue;

            

            // float maxDamage = player.GetTankController().GetTankModel().tankDamage;
            // float damage = CalculateDamage(targetRigidbody.position, maxDamage);
            
            // targetHealth.GetTankController().TakeDamage(damage);
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
