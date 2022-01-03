using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	public GameObject explosion;
	public SphereCollider sphereCol;
	public ParticleSystem trail;
	public Rigidbody rb;
	public AudioSource source;
	public float speed = 5f;
    public float radius = 10f;

    private void Start()
    {
		rb.velocity = new Vector3(0f,-1f,1f) * speed;
		Destroy(gameObject, 6f);
	}

    public void OnCollisionEnter(Collision col)
	{
		GameObject _exp =  Instantiate(explosion, transform.position,transform.rotation);
		source.Play();
		Destroy(_exp, 2f);
		Knockback();
		Destroy(gameObject);
	}

    private void Knockback()
    {
		Collider[] col = Physics.OverlapSphere(transform.position, radius);

		foreach(Collider near in col)
        {
			
			Rigidbody rb = near.GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.AddExplosionForce(10000f, transform.position, radius);
			}	
        }
    }
}
