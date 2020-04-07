using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private int bulletSpeed;
    public Rigidbody rb;
    public ParticleSystem bombExplosion;
    

    void Start()
    {
        FireBullet();
    }

    public void SetBulletDetails(BulletModel model)
    {

        bulletSpeed = model.Speed;
    }

    private void OnCollisionEnter(Collision collision)
    {   
        //Instantiate(bombExplosion, transform.position, transform.rotation);
        bombExplosion.Play();
        StartCoroutine(destroy());
    }

    IEnumerator  destroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

    }

    public void GetSpeed()
    {
         //rb = BulletPrefab.GetComponent<Rigidbody>();
        //rb.AddForce(spawner.forward * bulletSpeed * 100);
    }

    private void FireBullet()
    {
       

    }


}
