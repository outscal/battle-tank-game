using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Bullet
{

    public class BulletView : MonoBehaviour
    {
        private int bulletSpeed;
        private float bulletDamage;
        public Rigidbody rb;
        public ParticleSystem bombExplosion;
        private Vector3 spawnerPOS;

        private void Start()
        {
            //getSpeed();
            
        }

        public void SetBulletDetails(BulletModel model, Vector3 spawnerPos)
        {
            bulletSpeed = model.Speed;
            bulletDamage = model.Damage;
            spawnerPOS = spawnerPos;
            Debug.Log("setbullet details " + bulletSpeed);
        }

        private void getSpeed()
        {
            rb.velocity = new Vector3(0, 0, spawnerPOS.z) * bulletSpeed;
            //Debug.Log("get speed function speed " + bulletSpeed);
            //Debug.Log("get speed function rb velocity " + rb.velocity);
        }

        private void OnCollisionEnter(Collision collision)
        {
            //Instantiate(bombExplosion, transform.position, transform.rotation);
            bombExplosion.Play();
            if (collision.rigidbody != null)
            {
                collision.rigidbody.AddExplosionForce(2f, collision.transform.position, 1f);
            }
            else
            {
                rb.AddExplosionForce(2f, collision.transform.position, 1f);

            }
            StartCoroutine(destroy());
        }

        IEnumerator destroy()
        {
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);

        }
    }
}
