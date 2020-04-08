using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private int bulletSpeed;
    private float bulletDamage;
    public Rigidbody rb;
    public ParticleSystem bombExplosion;
    
    public void SetBulletDetails(BulletModel model)
    {
        bulletSpeed = model.Speed;
        bulletDamage = model.Damage;
    }

    private void OnCollisionEnter(Collision collision)
    {   
        //Instantiate(bombExplosion, transform.position, transform.rotation);
        bombExplosion.Play();
        if(collision.rigidbody != null )
        {
            collision.rigidbody.AddExplosionForce(2f,collision.transform.position,0.5f);
        }
        else
        {
            rb.AddExplosionForce(2f, collision.transform.position, 1f);

        }
        StartCoroutine(destroy());
    }

    IEnumerator  destroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

    }


}
